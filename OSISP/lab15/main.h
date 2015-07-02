#include <iostream>
#include <string>
#include <Windows.h>

using namespace std;

struct SystemPermission
{
	bool read;
	bool change;
};

struct SystemUser
{
	string name;
	int ssid;
};

struct SystemAce
{
	SystemUser user;
	SystemPermission permission;
};

struct SystemFile
{
	SystemUser owner;
	string name;
	SystemAce ace[4];
};

void Init();
void ViewPermissions();
void ReadPermissions(SystemUser su);
void ChangePermission(SystemUser su, SystemUser target, SystemPermission newPermission);
void ChangeOwner(SystemUser su, SystemUser target);
