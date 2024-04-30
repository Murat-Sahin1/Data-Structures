package main

import "fmt"

type Node struct {
	value    int
	downward *Node
}

type Stack struct {
	head **Node
}

func (r *Stack) createStack(val int) {
	var nodePtr = &Node{value: val}
	r.head = &nodePtr
}

func (r *Stack) populateList() {
	var tempNode *Node = *(r.head)
	tempNode.downward = &Node{}
	tempNode = tempNode.downward

	for i := 9; i >= 0; i-- {
		if i == 10 {
			tempNode.value = i
			tempNode.downward = nil
		}
		tempNode.value = i
		tempNode.downward = &Node{}
		tempNode = tempNode.downward
	}
}

func (r *Stack) printStack() {
	fmt.Println("Printing stack")

	var tempNode *Node = *(r.head)
	for ; tempNode.downward != nil; tempNode = tempNode.downward {
		fmt.Println("Node Value:", tempNode.value)
	}
}

func (r *Stack) push(newNode *Node) {
	newNode.downward = *(r.head)
	*(r.head) = newNode
	fmt.Println("Pushing: ", newNode.value)
}

func (r *Stack) printTopOfStack() {
	fmt.Println("Top of the stack:", (*(r.head)).value)
}

func (r *Stack) pop() *Node {
	var tempNode *Node = *r.head
	*(r.head) = (*(r.head)).downward

	fmt.Println("Popped: ", tempNode.value)
	return tempNode
}

func (r *Stack) addRange() {
	for i := 1; i <= 10; i++ {
		newNode := &Node{
			value: i * 10,
		}
		r.push(newNode)
	}
}

func main() {
	var root Stack = Stack{}
	root.createStack(4242)
	root.populateList()
	root.printStack()

	var myNewNode *Node = &Node{
		value: 234234,
	}

	root.push(myNewNode)
	root.printStack()
	root.printTopOfStack()
	root.pop()
	root.pop()
	root.pop()
	root.printStack()
	root.addRange()
	root.printStack()
}
