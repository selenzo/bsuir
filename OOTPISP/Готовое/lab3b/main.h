#include <iostream>

using namespace std;

class Matrix
{
public:
	Matrix();
	Matrix(int, int);
	~Matrix();
	void SetValue(int);
	void SetValue(int, int, int);
	void SetValue(int **, int, int, int);
	void ViewMatrix();
	void ViewMatrix(int, int, int ,int);
	void NewMatrix(int, int);
private:
	int **matrix;
	int m, n; //размеры матрицы
	void FreeMatrix(int **, int, int);
	int ** InitMatrix(int, int); // создает и зполн€ет нул€ми матрицу при создании
};