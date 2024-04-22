package main

import "fmt"

type RootNode struct {
	value int
	next  *Node
	// Designed to hold last element
	prev *Node
}

type Node struct {
	value int
	next  *Node
}

func (r *RootNode) populateList() {
	var tempNode *Node = &Node{}
	r.next = tempNode
	r.value = 0

	for i := 1; i <= 10; i++ {
		if i == 10 {
			tempNode.value = i
			tempNode.next = nil
			r.prev = tempNode
		}
		tempNode.value = i
		tempNode.next = &Node{}
		tempNode = tempNode.next
	}
}

func (r *RootNode) printList() {
	var tempNode *Node = &Node{value: r.value, next: r.next}
	for ; tempNode != nil; tempNode = tempNode.next {
		fmt.Println("Node Value:", tempNode.value)
	}
}

func (r *RootNode) push(newNode *Node) bool {
	r.prev.next = newNode
	r.prev = r.prev.next
	return true
}

func (r *RootNode) printTopOfStack() {
	fmt.Println("Top of the stack:", r.prev.value)
}

func (r *RootNode) addRange() {
	for i := 1; i <= 10; i++ {
		newNode := &Node{
			value: i * 10,
			next:  nil,
		}
		r.push(newNode)
	}
}

func main() {
	var root RootNode = RootNode{}
	root.populateList()
	// root.printList()
	// root.printTopOfStack()

	var myNewNode *Node = &Node{
		value: 123,
		next:  nil,
	}

	root.push(myNewNode)
	// root.printList()
	// root.printTopOfStack()
	root.addRange()
	root.printList()
}
