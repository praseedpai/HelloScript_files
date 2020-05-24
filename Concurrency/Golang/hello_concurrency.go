package concurrency

import (
	"fmt"
	"os"
	"os/signal"
	"sync"
	"time"
)

//Preamble: Unless explicitly programmed paralellism is a property of the runtime.
//			We cannot explicitly program for paralellism in golang.

//Expedition entry point, unravell the mistery, reduce up, reduce down, see as it is
func HelloRealWorld() {
	//Concurrency hello world - prints helloworld from goroutine
	//(`go` command Schedules a piece of code to be executed at the will of golang software defined scheduler,
	//such a scheduled function is called goroutine)
	//(other languages have things like fibers, green threads, threads, virtual threads, actors, coroutines etc
	//and ofcourse semantic differences are there between most of them)

	go helloWorld()

	//The synchronisation primitives one can see in a thread based model of concurrency is available in golang

	// go waitGroup()
	// go once()

	//Memory access in read write scenario

	// go unSafeAccess()
	// go notSoSafeAccess()
	// go reallySafeAccess()
	// go rightWayToAccess()

	//Pub sub example

	// go pubSub()

	//Go brings in a new concurrent data structure called channels (based on an old paper though) (Am I belittling the runtime by
	//calling it as a datastructure + operations? Sometimes risking reduction to basic parts are fine )
	//Channels along with their goroutine safe operators <-, -> makes asynchronous message passing easier in golang
	//There are some language constructs in golang to work with channels, we will see them as we proceed

	//Let's see the pubSub() example rewritten using channels

	// go pubSubChannels()
	// go channels()
	go mutualMessaging()

	//Signal watcher
	exitOnCtrlC()
}

func helloWorld() {
	//Hello World :  🙏 - K & R
	fmt.Println("Hello, World! 🙏 - K & R")
}

func waitGroup() {
	wg := sync.WaitGroup{}
	wg.Add(1)
	go func() {
		fmt.Print("Hello,")
		wg.Done()
	}()
	wg.Add(1)
	go func() {
		fmt.Print(" World!")
		wg.Done()
	}()
	//Waits for the two go routines to finish
	wg.Wait()
	fmt.Println(" - Wait Group")
}

func once() {
	var once sync.Once
	for i := 0; i < 3; i++ {
		go func(i int) {
			fmt.Println("Executing index: ", i)
			//First call to Do will be executed and everything else is discarded
			once.Do(func() {
				fmt.Println("Print i: ", i)
			})
		}(i)
	}
}

//Concurrent read and write
type CMap struct {
	Map map[string]int
	mtx sync.Mutex
}

type RMap struct {
	Map map[string]int
	mtx sync.RWMutex
}

// type Map struct {
// 	Map map[string]int // Map map[string]interface{}
// 	mtx sync.Locker // pass reference
// }

var cmap = CMap{make(map[string]int), sync.Mutex{}}
var rmap = RMap{make(map[string]int), sync.RWMutex{}}

func unSafeAccess() {
	go func() {
		for i := 0; i < 10; i++ {
			go func() {
				cmap.Map["x"] += 10
			}()
		}
	}()
	time.Sleep(1 * time.Second)
	fmt.Println("Value of x", cmap.Map["x"])
}

func notSoSafeAccess() {
	go func() {
		for i := 0; i < 10000; i++ {
			go func() {
				x := cmap.Map["x"]
				fmt.Println(x)
			}()
		}
	}()
	go func() {
		for i := 0; i < 1000; i++ {
			go func() {
				cmap.mtx.Lock()
				cmap.Map["x"] += 10
				cmap.mtx.Unlock()
			}()
		}
	}()
	// time.Sleep(1 * time.Second)
}

func reallySafeAccess() {
	go func() {
		for i := 0; i < 10000; i++ {
			go func() {
				cmap.mtx.Lock()
				x := cmap.Map["x"]
				cmap.mtx.Unlock()
				fmt.Println(x)
			}()
		}
	}()
	go func() {
		for i := 0; i < 1000; i++ {
			go func() {
				cmap.mtx.Lock()
				cmap.Map["x"] += 10
				cmap.mtx.Unlock()
			}()
		}
	}()
}

func rightWayToAccess() {
	go func() {
		for i := 0; i < 10000; i++ {
			go func() {
				rmap.mtx.RLock()
				defer rmap.mtx.RUnlock() //for precise control do not use defer
				x := rmap.Map["x"]
				fmt.Println(x)
			}()
		}
	}()
	go func() {
		for i := 0; i < 1000; i++ {
			go func() {
				rmap.mtx.Lock()
				defer rmap.mtx.Unlock() //for precise control do not use defer
				rmap.Map["x"] += 10
			}()
		}
	}()
}

//Interface defining the Queue category
type IQueue interface {
	Enqueue(val int)
	Dequeue() int
}

//Structure defining the Queue category
type Queue struct {
	data  []int
	cap   int
	rCond *sync.Cond //Segragates readers
	wCond *sync.Cond //Segragates writers
}

func ConstructQueue(cap uint32) *Queue {
	data := make([]int, 0)
	lock := new(sync.RWMutex)
	return &Queue{data, 10, sync.NewCond(lock), sync.NewCond(lock)}
}

//Enqueue - pushes a val to queue, waits for a notification from readers if the queue is full
func (q *Queue) Enqueue(val int) {
	q.wCond.L.Lock()
	for len(q.data) >= q.cap { //Cannot believe that the condition is true after a wakeup
		q.wCond.Wait() //Release the lock and goroutine will be moved to waitset of write cond
		//will be woken by a notification from the reader
	}
	q.data = append(q.data, val)
	q.rCond.Broadcast() //Notifies all goroutines waiting on read cond that a write has happened
	q.wCond.L.Unlock()
}

//Dequeue - pops a val from the queue, waits for a notification from writers if the queue is empty
func (q *Queue) Dequeue() int {
	q.rCond.L.Lock()
	for len(q.data) <= 0 { //Cannot believe that the condition is true after a wakeup
		q.rCond.Wait() //Release the lock and goroutine will be moved to waitset of read cond
		//will be woken by a notification from the writer
	}
	val := q.data[0]
	q.data = q.data[1:]
	q.wCond.Broadcast() //Notifies all goroutines waiting on write cond that a read has happened
	q.rCond.L.Unlock()  // for precise control do not use defer
	return val
}

func pubSub() {
	queue := ConstructQueue(10)
	go func() {
		for i := 10000; i >= 0; i-- {
			go func(i int) {
				queue.Enqueue(i)
			}(i)
		}
	}()

	go func() {
		for i := 0; i < 10000; i++ {
			go func() {
				val := queue.Dequeue()
				fmt.Println(val)
			}()
		}
	}()
}

func pubSubChannels() {
	//Construct a buffered integer channel of size 10 - make(chan int, 10)
	//Write to buffered channels will return immediately (uless the buffer is full, it will wait for someone to read from the
	//channel when the buffer is full)
	//Create unbuffered channels by just passing the type to make - make(chan int)
	//In an unbuffered channels write is blocking, when a goroutine is avaialble to read from the channel, writer is
	//unblocked and message is pushed to the other end
	chn := make(chan int, 10)
	go func() {
		for i := 10000; i >= 0; i-- {
			go func(i int) {
				chn <- i //pushing to channel
			}(i)
		}
	}()

	go func() {
		for i := 0; i < 10000; i++ {
			go func() {
				val := <-chn //retrieving from channel
				fmt.Println(val)
			}()
		}
	}()
}

//Special language constructs making use of the channel
func channels() {
	ch := make(chan interface{}, 10)
	go writeTochannel(ch)
	go readFromChannel(ch)
}

//Defines a formal parameter ch - send only channel
func writeTochannel(ch chan<- interface{}) {
	for i := 0; i < 10; i++ {
		ch <- i
	}
}

//Defined a formal parameter ch - recieve only channel
func readFromChannel(ch <-chan interface{}) {
	for {
		select {
		case i := <-ch:
			fmt.Println(i)
		}
	}
}

func mutualMessaging() {
	evenCh := make(chan int, 10)
	oddCh := make(chan int, 10)
	evenArr := []int{}
	oddArr := []int{}
	go func() {
		for {
			select {
			case a := <-evenCh:
				if a%2 == 0 {
					evenArr = append(evenArr, a)
				} else {
					fmt.Println("Not an even num - pushing to odd channel", a)
					oddCh <- a
				}
			}
		}
	}()

	go func() {
		for {
			select {
			case b := <-oddCh:
				if b%2 != 0 {
					oddArr = append(oddArr, b)
				} else {
					fmt.Println("Not an odd num - pushing to even channel", b)
					evenCh <- b
				}
			}
		}
	}()

	go func() {
		for i := 0; i < 10; i++ {
			evenCh <- i
		}
	}()

	go func() {
		for i := 10; i < 20; i++ {
			oddCh <- i
		}
	}()
}

//ctr + c cancellation support
func exitOnCtrlC() {
	c := make(chan os.Signal, 1)
	signal.Notify(c, os.Interrupt)
	for {
		select {
		case <-c:
			os.Exit(0)
		default:
		}
	}
}
