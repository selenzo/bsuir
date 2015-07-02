#include <iostream>
#include <windows.h>
#include <string>

using namespace std;

struct SystemUser
{
	int ssid;
	string name;
};

struct SystemFile
{
	string name;
	int owner;
	SystemAce ace;
};

struct Permission
{
	bool read;
	bool write;
	bool execute;
};

struct SystemAce
{
	SystemUser user;
	Permission rights;
};