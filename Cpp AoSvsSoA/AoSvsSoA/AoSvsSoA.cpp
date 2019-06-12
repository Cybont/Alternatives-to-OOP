// AoSvsSoA.cpp : This file contains the 'main' function. Program execution begins and ends there.

#include "pch.h"
#include <iostream>
#include <chrono>
#include <string>
#include <math.h>

const int iterations = 40000000;

class Entity {
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

	int A = rand() - 50;
	int B = rand() - 50;
	int C = rand() - 50;

	for (int i = 0; i < iterations; i++)
	{
		enArr[i].a = A;
		enArr[i].b = B;
		enArr[i].c = C;

		entities->a[i] = A;
		entities->b[i] = B;
		entities->c[i] = C;
	}

	auto start = std::chrono::high_resolution_clock::now();

	AoSTest(iterations, enArr);
	//SoATest(iterations, entities);

	auto finish = std::chrono::high_resolution_clock::now();
	std::chrono::duration<double> elapsed = finish - start;

	//std::cout << std::to_string(elapsed.count()) + "time";
	std::cout << std::to_string(std::chrono::duration_cast<std::chrono::seconds>(finish - start).count()) + "s";
}

void AoSTest(int iterations, Entity enArr[]) {
	for (int i = 0; i < iterations; i++)
	{	
		enArr[i].a = sqrt(enArr[i].a * enArr[i].c);
		enArr[i].c = sqrt(enArr[i].c * enArr[i].a);
		//std::cout << std::to_string(sqrt(enArr[i].a) + sqrt(enArr[i].b)) + "\n";
	}
}

void SoATest(int iterations, Entities* entities) {
	for (int i = 0; i < iterations; i++)
	{
		entities->a[i] = sqrt(entities->a[i] * entities->c[i]);
		entities->c[i] = sqrt(entities->c[i] * entities->a[i]);
		//std::cout << std::to_string(sqrt(entities->a[i]) + sqrt(entities->b[i])) + "\n";
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
