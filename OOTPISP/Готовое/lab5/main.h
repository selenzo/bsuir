#include <iostream>
#include <iomanip>
#include <string>

using namespace std;

template <typename T>
struct QueueItem
{
	T* data = NULL;
	QueueItem<T> * next = NULL;
};

template <typename T>
class Queue
{
public:
	Queue();
	~Queue();
	void Push(T* data);
	T* Pop();
	void View();
private:
	QueueItem<T> *queue = new QueueItem<T>;
	void AddItem(QueueItem<T>* st, T* data);
	void DeleteItem();
	void ViewQueue(QueueItem<T> *st);
};
