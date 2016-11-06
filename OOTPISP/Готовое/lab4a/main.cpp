#include "main.h"

int main(int argc, char *argv[])
{
	Book a;
	cout << "author 1 book " << a.GetAuthor() << endl;
	ArtBook b("minsk", "sidorov", 100, "fantastic");
	cout << "genre 2 book " << b.GetGenre() << endl;
	ScientificBook c;
	cout << "pagecount 3 book " << c.GetPageCount() << endl;

	system("pause");
	return 0;
}

Book::Book()
{
	publisher = "123";
	author = "Ivanov";
	pageCount = 300;
}

Book::Book(string p, string a, int pc)
{
	publisher = p;
	author = a;
	pageCount = pc;
}

Book::~Book()
{

}

ArtBook::ArtBook()
{
	publisher = "123";
	author = "Ivanov";
	pageCount = 300;
	genre = "test";
}

ArtBook::ArtBook(string p, string a, int pc, string g)
{
	publisher = p;
	author = a;
	pageCount = pc;
	genre = g;
}

ArtBook::~ArtBook()
{

}

ScientificBook::~ScientificBook()
{

}

ScientificBook::ScientificBook()
{
	publisher = "123";
	author = "Ivanov";
	pageCount = 300;
	subjects = "science";
	complexity = 3;
}

ScientificBook::ScientificBook(string p, string a, int pc, string s, int c)
{
	publisher = p;
	author = a;
	pageCount = pc;
	subjects = s;
	complexity = c;
}
