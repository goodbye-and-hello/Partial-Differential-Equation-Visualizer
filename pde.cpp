// ===========================================================
// 
//       Filename:  PDE.cpp
//        Created:  2018.04.18 
//       Compiler:  vs2015
//         Author:  ssibongee, ssibongee@yonsei.ac.kr
//        Company:  Yonsei univ.
// 
// ===========================================================

/*
	Test File for Creating PDE Algoritm
*/
#include <iostream>
#include <vector>	
#include <windows.h>
using namespace std;

/* 
	MAX	: Matrix's row & col
*/
#define MAX 10
int x[] = { -1, 0, 1, 0 };
int y[] = { 0, -1, 0, 1 };

/*
	safe(x, y) : check array[x][y] is available
*/
bool safe(int x, int y)
{
	return (x >= 0 && x<MAX && y >= 0 && y<MAX);
}


/*
	PDE Function 
*/
bool pde(int m[][MAX]) {
	int row, col;
	int mc[MAX][MAX];
	memset(mc, 0, sizeof(mc));

	for (row = 0; row < MAX; row++) {
		for (col = 0; col < MAX; col++) {
			vector<int> s;
			for (int i = 0; i < 4; i++) {
				int dx = row + x[i];
				int dy = col + y[i];
				if (safe(dx, dy)) {
					s.push_back(m[dx][dy]);
				}
			}
			int pde = 0;
			for (auto v : s) {
				pde += v;
			}
			mc[row][col] = pde /= 4;

		}
	}
	int flag = 1;
	int c = 0;

	for (row = 0; row < MAX; row++) {
		for (col = 0; col < MAX; col++) {
			m[row][col] = mc[row][col];
		}
	}
	for (row = 0; row < MAX; row++) {
		for (col = 0; col < MAX; col++) {
			if (!m[row][col])
				c++;
		}
	}
	if (c == (MAX*MAX))
		return 0;
	return 1;
}

int main() {
	int m[MAX][MAX];
	int count = 0;
	for (int i = 0; i < MAX; i++) {
		for (int j = 0; j < MAX; j++) {
			m[i][j] = 100;
		}
	}
	fgetc(stdin);
	while(pde(m)) {
		for (int i = 0; i < MAX; i++) {
			for (int j = 0; j < MAX; j++) {
				cout << m[i][j] << "\t";
			}
			cout << endl << endl;
		}
		count++;
		system("cls");
		Sleep(75);
	} 
	for (int i = 0; i < MAX; i++) {
		for (int j = 0; j < MAX; j++) {
			cout << m[i][j] << "\t";
		}
		cout << endl << endl;
	}

	cout << count << endl;
}
