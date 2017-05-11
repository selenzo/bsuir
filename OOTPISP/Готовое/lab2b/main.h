#include <iostream>
#include <string.h>

using namespace std;

struct Cord
{
	int x;
	int y;
};

struct Rectangle
{
	Cord leftbottom;
	Cord righttop;
};


class Rectangles
{
public:
	Rectangles();
	Rectangles(Rectangle rect1, Rectangle rect2);
	~Rectangles();
	void Move(int number, int moveX, int moveY);	//двигаем указанный по номеру прямоугольник на х или у
	void Resize(int number, int x1, int y1, int x2, int y2);		//задаем новые координаты для выбранног опрямоугольника
	Rectangle IntersectionRectangle();				//находим пересечение прямоугольников
	Rectangle UnionRectangle();						//находим наименьший, что включает оба
	void ViewRectangles();							//просмотр текущих прямоугольников

private:
	Rectangle rectangles[2];
	void SwapRectangles();							//меняем прямоугольники, что бы первый был левее
};