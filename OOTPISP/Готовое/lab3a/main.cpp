
#include "main.h"

/*
Задание А4. Определите в классе String следующие


char operator[](int);//получить символ
*/

int main(int argc, char *argv[])
{
	String a, b;
	a.SetString("abc");
	cout << "default " << a.GetString() << endl;;
	b.SetString(" b string");
	a = b;
	cout << "after =b " << a.GetString() << endl;;

	char *c = " from c";

	a = c;
	cout << "after =c " << a.GetString() << endl;

	a += b;
	cout << "after +b " << a.GetString() << endl;;

	a += c;
	cout << "after +c " << a.GetString() << endl;

	cout << "char position 3 " << a[3] << endl;

	system("pause");
	return 0;
}

String::String()
{

}

String::~String()
{

}

void String::SetString(string tmp)
{
	str = tmp;
}

string String::GetString()
{
	return str;
}

String& String::operator= (const String& tmp)
{
	if (this == &tmp) return *this;

	str = tmp.str;

	return *this;
}

String& String::operator+= (const String& tmp)
{
	if (this == &tmp) return *this;

	str += tmp.str;

	return *this;
}

String& String::operator= (char * a)
{
	string tmp(a);
	str = tmp;
	return *this;
}

String& String::operator+= (char * a)
{
	string tmp(a);
	str += tmp;
	return *this;
}

char& String::operator[] (int pos)
{
	char tmp = '\0';
	if (pos < str.length())
	{
		return str[pos];
	}
	else
	{
		return tmp;
	}
}