#include <stdio.h>
#include <stdlib.h>

// Main node struct
typedef struct n node;
struct n {
  int data;
  node *next;
};

int length = 0;

// MAIN FUNCTIONALITY

void insert(node **head, int x, int index) {
  if ((index > length) || (index < 0)) {
    printf("\nIndex out of bounds.");
    return;
  }

  // NOTE : Check if are we inserting to root or the head is null
  if (index == 0 || *head == NULL) {
    node *temp = (node *)malloc(sizeof(node));
    if (*head == NULL) {
      temp->next = NULL;
    } else {
      temp->next = *head;
    }
    temp->data = x;
    *head = temp;
    length++;
    return;
  }

  node *trav = *head;
  for (int i = 0; i != index - 1; i++) {
    trav = trav->next;
  }
  node *temp = (node *)malloc(sizeof(node));
  temp->data = x;
  temp->next = trav->next;
  trav->next = temp;
  length++;
}

void add(node **head, int x) {}

// UTILITIES

void print_list(node *head) {
  node *temp = head;
  printf("\nYour list: ");
  while (temp->next != NULL) {
    printf("%d ->", temp->data);
    temp = temp->next;
  }
  printf("%d", temp->data);
}

void test_fill_items(node *head) {
  node *temp = head;
  for (int i = 0; i < 10; i++) {
    temp->next = (node *)malloc(sizeof(node));
    temp->data = i;
    // printf("%d", (*temp)->data);
    temp->next->next = NULL;
    temp = temp->next;
    length++;
  }
}

void print_length() { printf("\nLinked List Length: %d", length); }

int main() {
  node *head = NULL; /* (node *)malloc(sizeof(node)); */
  // test_fill_items(head);
  // print_list(head);
  // NOTE : Item will be at the specified index
  insert(&head, 42, 0);
  printf("%d", head->data);
  print_list(head);
  insert(&head, 42, 1);
  print_list(head);
  insert(&head, 42, 2);
  print_list(head);
  print_length();
  insert(&head, 11, 23);
  print_list(head);
  insert(&head, 238, 0);
  print_list(head);
  // insert(&head, 42, 5);
  // print_list(head);
  // insert(&head, 12, 0);
  // print_list(head);
  return 0;
}
