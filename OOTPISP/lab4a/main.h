#include <iostream>
#include <string>

using namespace std;

class Book
{
public:
	Book();
	Book(string, string, int);
	~Book();

	void SetPublisher(string str) {publisher = str; };
	void SetAuthor(string str) { author = str; };
	void SetPageCount(int a) { pageCount = a; };
	string GetPublisher() { return publisher; };
	string GetAuthor() { return author; };
	int GetPageCount() { return pageCount; };


protected:
	string publisher;
	string author;
	int pageCount;
};


class ArtBook : public Book
{
public:
	ArtBook();
	ArtBook(string, string, int, string);
	~ArtBook();
	void SetGenre(string str) { genre = str; };
	string GetGenre() { return genre; };
private:
	string genre;
};

class ScientificBook : public Book
{
public:
	ScientificBook();
	ScientificBook(string, string, int, string, int);
	~ScientificBook();
	void SetSubjects(string str) { subjects = str; };
	string GetSubjects() { return subjects; };
	void SetComplexity(int a) { complexity = a; };
	int GetComplexity() { return complexity; };
private:
	string subjects;
	int complexity;
};