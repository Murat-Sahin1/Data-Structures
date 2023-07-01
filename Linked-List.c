#include <stdio.h>
#include <stdlib.h>

typedef struct n node;
struct n {
  int data;
  node *next;
};

// void test_fill_items(node **head) {
//   node **temp = head;
//   for (int i = 0; i < 10; i++) {
//     (*temp)->next = (node *)malloc(sizeof(node));
//     (*temp)->data = i;
//     // printf("%d", (*temp)->data);
//     (*temp)->next->next = NULL;
//     (*temp) = (*temp)->next;
//   }
//   (*temp)->next = NULL;
// }

// void print_list(node **head) {
//   node **temp = head;
//   int i;
//   printf("\nYour list: ");
//   while (i != 10) {
//     printf("%d ->", (*temp)->data);
//     *temp = (*temp)->next;
//     i++;
//   }
//   printf("%d", (*temp)->data);
// }

void print_list(node *head) {
  node *temp = head;
  printf("\nYour list: ");
  while (temp->next->next != NULL) {
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
  }
}

int main() {
  node *head = (node *)malloc(sizeof(node));
  test_fill_items(head);
  print_list(head);
  return 0;
}
