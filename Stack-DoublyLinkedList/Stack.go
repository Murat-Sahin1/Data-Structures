package main

import "fmt"

type Node struct {
	value int
	next  *Node
	prev  *Node
}

func (r *Node) populateList() {
	var prevNode *Node = r
	var tempNode *Node = &Node{}
	r.next = tempNode

	for i := 1; i <= 10; i++ {
		if i == 10 {
			tempNode.value = i
			tempNode.next = nil
			tempNode.prev = prevNode
			r.prev = tempNode
		}
		tempNode.value = i
		tempNode.next = &Node{}
		tempNode.prev = prevNode
		tempNode = tempNode.next
		prevNode = prevNode.next
	}
}

// NOTE: PrintList pushes each func call to the stack per iteration
// then executes with LIFO order.
func (r *Node) printStackForward() {
	fmt.Println("Printing stack forward")
	var tempNode *Node = r
	for ; tempNode != nil; tempNode = tempNode.next {
		defer fmt.Println("Node Value:", tempNode.value)
	}
}

func (r *Node) printStackReverse() {
	fmt.Println("Printing stack in reverse")

	var tempNode *Node = r.prev
	fmt.Println("Node Value:", tempNode.value)
	tempNode = tempNode.prev

	for ; tempNode != r.prev; tempNode = tempNode.prev {
		fmt.Println("Node Value:", tempNode.value)
	}
}

func (r *Node) push(newNode *Node) bool {
	if r.prev == nil {
		fmt.Println("Last element of the stack is null. Terminating...")
		return false
	}
	r.prev.next = newNode
	newNode.prev = r.prev
	r.prev = r.prev.next
	return true
}

func (r *Node) pop() *Node {
	fmt.Println("Popped...")
	var tempNode *Node = r.prev
	r.prev = r.prev.prev
	r.prev.next = nil
	return tempNode
}

func (r *Node) printTopOfStack() {
	fmt.Println("Top of the stack:", r.prev.value)
}

func (r *Node) addRange() {
	for i := 1; i <= 10; i++ {
		newNode := &Node{
			value: i * 10,
			next:  nil,
		}
		r.push(newNode)
	}
}

func main() {
	var root Node = Node{}
	root.populateList()

	var myNewNode *Node = &Node{
		value: 123,
		next:  nil,
	}

	root.push(myNewNode)
	// root.printList()
	root.printTopOfStack()
	root.addRange()
	root.printStackForward()
	root.printStackReverse()
	root.pop()
	root.pop()
	root.pop()
	root.pop()
	root.printStackReverse()
	root.printStackForward()
}
