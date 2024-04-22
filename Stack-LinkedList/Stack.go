package main

import "fmt"

type Node struct {
	value int
	next  *Node
}

func (n *Node) populateList() {
	var tempNode *Node = n
	for i := 0; i < 10; i++ {
		if i == 9 {
			tempNode.value = i
			tempNode.next = nil
		}
		tempNode.value = i
		tempNode.next = &Node{}
		tempNode = tempNode.next
	}
}

func (n *Node) printList() {
	var tempNode *Node = n
	for ; tempNode.next != nil; tempNode = tempNode.next {
		fmt.Println("Node Value:", tempNode.value)
	}
}

func main() {
	var root Node = Node{value: 0, next: nil}
	root.populateList()
	root.printList()
}
