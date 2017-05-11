#include "main.h"

SystemUser users[4];
SystemFile files;


/*
на примере реализована дискретная модель безопасности
*/
int main(int argc, char *argv[])
{
	//инициализиурем
	Init();
	
	//смотри все разрешения
	ViewPermissions();

	//попытаемся читать разрешения если нам это не дано правами
	cout << endl << "read permissions Ivan" << endl;
	ReadPermissions(users[3]);

	//добавим прав ивану на изменение От имени владельца
	cout << endl << "change permissions Ivan" << endl;
	SystemPermission temp;
	temp.change = true;
	temp.read = true;
	ChangePermission(files.owner, users[3], temp);

	//проверям что сработало
	cout << endl << "read permissions Ivan" << endl;
	ReadPermissions(users[3]);

	//поменяем владельца на ивана от имени текущего владельца
	cout << endl << "change owner to Ivan" << endl;
	ChangeOwner(files.owner, users[3]);

	//смотри все разрешения
	ViewPermissions();

	system("pause");
	return 0;
}

void Init()
{
	//root
	users[0].name = "root";
	users[0].ssid = 0;

	users[1].name = "Vasya";
	users[2].name = "Petya";
	users[3].name = "Ivan";

	users[1].ssid = 1;
	users[2].ssid = 2;
	users[3].ssid = 3;

	files.name = "file1";
	files.owner = users[2];

	files.ace[0].user = users[0];
	files.ace[0].permission.read = true;
	files.ace[0].permission.change = true;

	files.ace[1].user = users[1];
	files.ace[1].permission.read = true;
	files.ace[1].permission.change = false;

	files.ace[2].user = users[2];
	files.ace[2].permission.read = true;
	files.ace[2].permission.change = true;

	files.ace[3].user = users[3];
	files.ace[3].permission.read = false;
	files.ace[3].permission.change = false;
}

void ViewPermissions()
{
	cout << files.name << endl;
	cout << "Owner: " << files.owner.name << endl << endl;
	for (int i = 0; i < 4; i++)
	{
		cout << files.ace[i].user.name << " read " << files.ace[i].permission.read << " change " << files.ace[i].permission.change << endl;
	}
}

void ReadPermissions(SystemUser su)
{
	if (su.ssid == 0 || files.owner.ssid == su.ssid || files.ace[su.ssid].permission.read)
	{
		ViewPermissions();
	}
	else
	{
		cout << "Access denied!" << endl;
	}
}

void ChangePermission(SystemUser su, SystemUser target, SystemPermission newPermission)
{
	if (su.ssid == 0 || files.owner.ssid == su.ssid || files.ace[su.ssid].permission.change)
	{
		if (target.ssid == 0 || files.owner.ssid == target.ssid)
		{
			cout << "Denied change permission to root or owner" << endl;
		}
		else
		{
			files.ace[target.ssid].permission.change = newPermission.change;
			files.ace[target.ssid].permission.read = newPermission.read;
		}
	}
	else
	{
		cout << "Access denied!" << endl;
	}
}

void ChangeOwner(SystemUser su, SystemUser target)
{
	if (su.ssid == 0 || files.owner.ssid == su.ssid)
	{
		files.owner = target;
	}
	else
	{
		cout << "Access denied!" << endl;
	}
}