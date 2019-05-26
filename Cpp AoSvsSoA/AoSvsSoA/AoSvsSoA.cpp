// AoSvsSoA.cpp : This file contains the 'main' function. Program execution begins and ends there.

#include "pch.h"
#include <iostream>
#include <chrono>
#include <string>
#include <math.h>

const int iterations = 100000;

struct Entity {
public:
	float a, b, c;
};

struct Entities {
public:
	float a[iterations];
	float b[iterations];
	float c[iterations];
};

void AoSTest(int iterations, Entity enArr[]);

void SoATest(int iterations, Entities* entities);

int main()
{
	Entity* enArr = new Entity[iterations];

	Entities* entities = new Entities;

	for (int i = 0; i < iterations; i++)
	{
		enArr[i].a = rand() - 50;
		enArr[i].b = rand() - 50;
		enArr[i].c = rand() - 50;

		entities->a[i] = rand() - 50;
		entities->b[i] = rand() - 50;
		entities->c[i] = rand() - 50;
	}

	auto start = std::chrono::high_resolution_clock::now();

	AoSTest(iterations, enArr);
	//SoATest(iterations, entities);

	auto finish = std::chrono::high_resolution_clock::now();
	std::chrono::duration<double> elapsed = finish - start;

	std::cout << std::to_string(elapsed.count());
}

void AoSTest(int iterations, Entity enArr[]) {
	for (int i = 0; i < iterations; i++)
	{		
		std::cout << std::to_string(sqrt(enArr[i].a) + sqrt(enArr[i].b)) + "\n";
	}
}

void SoATest(int iterations, Entities* entities) {
	for (int i = 0; i < iterations; i++)
	{
		std::cout << std::to_string(sqrt(entities->a[i]) + sqrt(entities->b[i])) + "\n";
	}
}

// Run program: Ctrl + F5 or Debug > Start Without Debugging menu
// Debug program: F5 or Debug > Start Debugging menu

// Tips for Getting Started: 
//   1. Use the Solution Explorer window to add/manage files
//   2. Use the Team Explorer window to connect to source control
//   3. Use the Output window to see build output and other messages
//   4. Use the Error List window to view errors
//   5. Go to Project > Add New Item to create new code files, or Project > Add Existing Item to add existing code files to the project
//   6. In the future, to open this project again, go to File > Open > Project and select the .sln file
