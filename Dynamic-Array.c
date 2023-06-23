#include <stdbool.h>
#include <stdio.h>
#include <stdlib.h>

int FIXED_LENGTH = 0;
int length = 0;
int capacity = 16;
int static_array[16];

void add(int **first_cell, int newInt) {
  if (capacity == 0) {
    capacity = 16;
  }
  if (length + 1 >= capacity) {
    // Create new array and assign it
    printf("\nCreating the new double sized array, inserting: ");
    capacity = capacity * 2;
    int *newArr = (int *)malloc(capacity * sizeof(int));
    for (int i = 0; i < length; i++) {
      newArr[i] = (*first_cell)[i];
      printf("%d ", newArr[i]);
    }
    // Does this free every cell in array?
    // free(first_cell);
    *first_cell = newArr;
  }
  (*first_cell)[length] = newInt;
  length++;
  printf("\nAdded %d into the array.", (*first_cell)[length - 1]);
}

void test_fill_the_array(int *first_cell) {
  for (int i = 0; i < capacity; i++) {
    first_cell[i] = i;
    printf("%d\n", first_cell[i]);
    length++;
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

void print_array(int *first_cell) {
  printf("\nFull array: [%d", first_cell[0]);
  for (int i = 1; i < length; ++i) {
    printf(",");
    printf("%d", first_cell[i]);
  }
  printf("]\n");
}

void to_infinity_and_beyond(int **first_cell) {
  int i = 0;
  while (getchar() != 'e') {
    // char c = getchar();
    // if (c == 'e')
    //   break;
    add(first_cell, i);
    print_array(*first_cell);
    i++;
  }
}

void set_capacity(int _cap) { capacity = _cap; }

void print_capacity() { printf("\nCapacity: %d", capacity); }

int get_length() { return length; }

int size() { return length; }

bool isEmpty() { return length == 0; }

int main() {
  printf("Program started...\n");

  int *root = (int *)malloc(capacity * sizeof(int));

  set_capacity(3);
  print_capacity();
  printf("\nCurrent size: %d\n", get_length());

  // add(&root, 0);
  // add(&root, 1);
  // add(&root, 2);

  to_infinity_and_beyond(&root);

  // print_array(root);

  // printf("\n%d\n", root[0]);
  // printf("\n%d\n", root[1]);
  // printf("\n%d\n", root[2]);

  // print_capacity();
  // printf("\nCurrent size: %d\n", get_length());

  return 0;
}
