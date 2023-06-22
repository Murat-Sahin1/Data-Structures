#include <stdbool.h>
#include <stdio.h>
#include <stdlib.h>

int FIXED_LENGTH = 0;
int length = 0;
int capacity = 16;
int static_array[16];

void test_fill_the_array(int *first_cell) {
  for (int i = 0; i < capacity; i++) {
    first_cell[i] = i;
    printf("%d", first_cell[i]);
  }
}

int get(int *first_cell, int index) {
  if ((index < 0) || (index > capacity)) {
    exit(1);
  }

  for (int i = 0; i < capacity; i++) {
    if (i == index) {
      return first_cell[i];
    }
  }

  return 0;
}

int size() { return length; }

bool isEmpty() { return length == 0; }

int main() {
  printf("Program started...");
  int *root = (int *)malloc(capacity * sizeof(int));
  test_fill_the_array(root);
  int temp = get(root, 15);
  printf("%d", temp);

  return 0;
}
