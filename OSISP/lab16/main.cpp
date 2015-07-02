
#include "main.h"

/*
трешовая лаба. Перед тем, как запускать, необходимо создать пользователя test123 в системе

ReadAce(); показывает текущие разрешения
затем добавляется новый АСЕ для test123 с чтением папок и атрибутов (проверить можно в свойствах)
ReadAce(); показывает текущие разрешения
удаление первого АСЕ (это то, что бы добавляли на прошлом шаге)
ReadAce(); показывает текущие разрешения


ФИЧА!!! АЛЕРТ!!! работает только раз, поэтому в слеующий раз необходимо пересоздавать каталог
это происходит из-за неправильного удаления АСЕ (там повляется ошибка в размере DACL)
*/

int main()
{
	ReadAce();
		
	wchar_t wchDirName[248] = L"test";       // имя каталога
	wchar_t wchUserName[UNLEN] = L"test123";    // имя пользователя

	ACL *lpOldDacl;    // указатель на старый DACL
	ACL *lpNewDacl;    // указатель на новый DACL
	LPVOID lpAce;      // указатель на элемент ACE

	DWORD dwDaclLength = 0;        // длина DACL
	DWORD dwSdLength = 0;          // длина SD
	DWORD dwSidLength = 0;         // длина SID
	DWORD dwLengthOfDomainName = 0;    // длина имени домена

	PSID lpSid = NULL;             // указатель на разрешающий SID
	LPTSTR lpDomainName = NULL;    // указатель на имя домена

	SID_NAME_USE typeOfSid;        // тип учетной записи

	SECURITY_DESCRIPTOR *lpSd = NULL;  // адрес дескриптора безопасности
	SECURITY_DESCRIPTOR sdAbsoluteSd;  // абсолютный формат SD
	BOOL bDaclPresent;             // признак присутствия списка DACL
	BOOL bDaclDefaulted;           // признак списка DACL по умолчанию

	DWORD dwRetCode;   // код возврата

	// получаем длину дескриптора безопасности
	if (!GetFileSecurity(
		wchDirName,    // имя файла
		DACL_SECURITY_INFORMATION,   // получаем DACL
		lpSd,          // адрес дескриптора безопасности
		0,             // определяем длину буфера
		&dwSdLength))  // адрес для требуемой длины
	{
		dwRetCode = GetLastError();

		if (dwRetCode == ERROR_INSUFFICIENT_BUFFER)
			// распределяем память для буфера
			lpSd = (SECURITY_DESCRIPTOR*) new char[dwSdLength];
		else
		{
			// выходим из программы
			printf("Get file security failed.\n");
			printf("Error code: %d\n", dwRetCode);

			return dwRetCode;
		}
	}

	// читаем дескриптор безопасности
	if (!GetFileSecurity(
		wchDirName,    // имя файла
		DACL_SECURITY_INFORMATION,   // получаем DACL
		lpSd,          // адрес дескриптора безопасности
		dwSdLength,    // длину буфера
		&dwSdLength))  // адрес для требуемой длины
	{
		dwRetCode = GetLastError();
		printf("Get file security failed.\n");
		printf("Error code: %d\n", dwRetCode);

		return dwRetCode;
	}

	// определяем длину SID пользователя
	if (!LookupAccountName(
		NULL,          // ищем имя на локальном компьютере
		wchUserName,   // имя пользователя
		NULL,          // определяем длину SID
		&dwSidLength,  // длина SID
		NULL,          // определяем имя домена
		&dwLengthOfDomainName,     // длина имени домена
		&typeOfSid))   // тип учетной записи
	{
		dwRetCode = GetLastError();

		if (dwRetCode == ERROR_INSUFFICIENT_BUFFER)
		{
			// распределяем память для SID
			lpSid = (SID*) new char[dwSidLength];
			lpDomainName = (LPTSTR) new wchar_t[dwLengthOfDomainName];
		}
		else
		{
			// выходим из программы
			printf("Lookup account name failed.\n");
			printf("Error code: %d\n", dwRetCode);

			return dwRetCode;
		}
	}

	// определяем SID
	if (!LookupAccountName(
		NULL,          // ищем имя на локальном компьютере
		wchUserName,   // имя пользователя
		lpSid,         // указатель на SID
		&dwSidLength,  // длина SID
		lpDomainName,  // указатель на имя домена
		&dwLengthOfDomainName,   // длина имени домена
		&typeOfSid))   // тип учетной записи
	{
		dwRetCode = GetLastError();

		printf("Lookup account name failed.\n");
		printf("Error code: %d\n", dwRetCode);

		return dwRetCode;
	}

	// получаем список DACL из дескриптора безопасности
	if (!GetSecurityDescriptorDacl(
		lpSd,              // адрес дескриптора безопасности
		&bDaclPresent,     // признак присутствия списка DACL
		&lpOldDacl,        // адрес указателя на DACL
		&bDaclDefaulted))  // признак списка DACL по умолчанию
	{
		dwRetCode = GetLastError();
		printf("Get security descriptor DACL failed.\n");
		printf("Error code: %d\n", dwRetCode);

		return dwRetCode;
	}

	// определяем длину нового DACL
	dwDaclLength = lpOldDacl->AclSize +
		sizeof(ACCESS_ALLOWED_ACE)-sizeof(DWORD)+dwSidLength;

	// распределяем память под новый DACL
	lpNewDacl = (ACL*)new char[dwDaclLength];

	// инициализируем новый DACL
	if (!InitializeAcl(
		lpNewDacl,       // адрес DACL
		dwDaclLength,    // длина DACL
		ACL_REVISION))   // версия DACL
	{
		dwRetCode = GetLastError();

		printf("Lookup account name failed.\n");
		printf("Error code: %d\n", dwRetCode);

		return dwRetCode;
	}

	// добавляем нового элемент в новый DACL
	if (!AddAccessAllowedAce(
		lpNewDacl,       // адрес DACL
		ACL_REVISION,    // версия DACL
		FILE_WRITE_DATA | FILE_READ_DATA,  // запрещаем писать атрибуты
		lpSid))          // адрес SID
	{
		dwRetCode = GetLastError();
		perror("Add access allowed ace failed.\n");
		printf("The last error code: %u\n", dwRetCode);

		return dwRetCode;
	}

	// получаем адрес первого ACE в старом списке DACL
	if (!GetAce(
		lpOldDacl,     // адрес старого DACL
		0,             // ищем первый элемент
		&lpAce))       // адрес первого элемента
	{
		dwRetCode = GetLastError();

		printf("Get ace failed.\n");
		printf("Error code: %d\n", dwRetCode);

		return dwRetCode;
	}

	// переписываем элементы из старого DACL в новый DACL
	if (bDaclPresent)
	{	
		if (!AddAce(
			lpNewDacl,       // адрес нового DACL
			ACL_REVISION,    // версия DACL
			MAXDWORD,        // добавляем в конец списка
			lpAce,           // адрес старого DACL
			lpOldDacl->AclSize - sizeof(ACL)))  // длина старого DACL
		{
			dwRetCode = GetLastError();
			perror("Add access allowed ace failed.\n");
			printf("The last error code: %u\n", dwRetCode);

			return dwRetCode;
		}
	}

	// проверяем достоверность DACL
	if (!IsValidAcl(lpNewDacl))
	{
		dwRetCode = GetLastError();
		perror("The new ACL is invalid.\n");
		printf("The last error code: %u\n", dwRetCode);

		return dwRetCode;
	}

	// создаем новый дескриптор безопасности в абсолютной форме
	if (!InitializeSecurityDescriptor(
		&sdAbsoluteSd,       // адрес структуры SD
		SECURITY_DESCRIPTOR_REVISION))
	{
		dwRetCode = GetLastError();
		perror("Initialize security descriptor failed.\n");
		printf("The last error code: %u\n", dwRetCode);

		return dwRetCode;
	}

	// устанавливаем DACL  в новый дескриптор безопасности
	if (!SetSecurityDescriptorDacl(
		&sdAbsoluteSd,   // адрес дескриптора безопасности
		TRUE,            // DACL присутствует
		lpNewDacl,       // указатель на DACL
		FALSE))          // DACL не задан по умолчанию
	{
		dwRetCode = GetLastError();
		perror("Set security descriptor DACL failed.\n");
		printf("The last error code: %u\n", dwRetCode);

		return dwRetCode;
	}

	// проверяем структуру дескриптора безопасности
	if (!IsValidSecurityDescriptor(&sdAbsoluteSd))
	{
		dwRetCode = GetLastError();
		perror("Security descriptor is invalid.\n");
		printf("The last error code: %u\n", dwRetCode);

		return dwRetCode;
	}
	// устанавливаем новый дескриптор безопасности
	if (!SetFileSecurity(
		wchDirName,        // имя файла
		DACL_SECURITY_INFORMATION,     // устанавливаем DACL
		&sdAbsoluteSd))    // адрес дескриптора безопасности
	{
		dwRetCode = GetLastError();
		printf("Set file security failed.\n");
		printf("Error code: %d\n", dwRetCode);

		return dwRetCode;
	}

	ReadAce();

	DeleteAce(lpNewDacl, 0);

	// проверяем достоверность DACL
	if (!IsValidAcl(lpNewDacl))
	{
		dwRetCode = GetLastError();
		perror("The new ACL is invalid.\n");
		printf("The last error code: %u\n", dwRetCode);

		return dwRetCode;
	}

	// создаем новый дескриптор безопасности в абсолютной форме
	if (!InitializeSecurityDescriptor(
		&sdAbsoluteSd,       // адрес структуры SD
		SECURITY_DESCRIPTOR_REVISION))
	{
		dwRetCode = GetLastError();
		perror("Initialize security descriptor failed.\n");
		printf("The last error code: %u\n", dwRetCode);

		return dwRetCode;
	}

	// устанавливаем DACL  в новый дескриптор безопасности
	if (!SetSecurityDescriptorDacl(
		&sdAbsoluteSd,   // адрес дескриптора безопасности
		TRUE,            // DACL присутствует
		lpNewDacl,       // указатель на DACL
		FALSE))          // DACL не задан по умолчанию
	{
		dwRetCode = GetLastError();
		perror("Set security descriptor DACL failed.\n");
		printf("The last error code: %u\n", dwRetCode);

		return dwRetCode;
	}

	// проверяем структуру дескриптора безопасности
	if (!IsValidSecurityDescriptor(&sdAbsoluteSd))
	{
		dwRetCode = GetLastError();
		perror("Security descriptor is invalid.\n");
		printf("The last error code: %u\n", dwRetCode);

		return dwRetCode;
	}
	// устанавливаем новый дескриптор безопасности
	if (!SetFileSecurity(
		wchDirName,        // имя файла
		DACL_SECURITY_INFORMATION,     // устанавливаем DACL
		&sdAbsoluteSd))    // адрес дескриптора безопасности
	{
		dwRetCode = GetLastError();
		printf("Set file security failed.\n");
		printf("Error code: %d\n", dwRetCode);

		return dwRetCode;
	}

	ReadAce();

	// освобождаем память
	delete[] lpSd;
	delete[] lpSid;
	delete[] lpDomainName;
	delete[] lpNewDacl;

	return 0;
}


int ReadAce()
{
	setlocale(0, "");

	system("cls");
	LPCWSTR fname = L"test";

	//fname = L"C:\\windows";

	wcout << "file:" << fname << "\n";

	PSECURITY_DESCRIPTOR psd = NULL;
	PACL pdacl;
	ACL_SIZE_INFORMATION aclSize = { 0 };
	PSID sidowner = NULL;
	PSID sidgroup = NULL;


	ULONG result = GetNamedSecurityInfo(fname
		, SE_FILE_OBJECT
		, OWNER_SECURITY_INFORMATION | GROUP_SECURITY_INFORMATION | DACL_SECURITY_INFORMATION
		, &sidowner
		, &sidgroup
		, &pdacl
		, NULL
		, &psd); 

	//if (result != ERROR_SUCCESS){ return NULL; }

	wchar_t oname[256];
	wchar_t asd[4] = L"абц";
	DWORD namelen;
	wchar_t* doname = new TCHAR[512];
	DWORD domainnamelen;
	SID_NAME_USE peUse;
	ACCESS_ALLOWED_ACE* ace;

 	LookupAccountSid(NULL, sidowner, oname, &namelen, doname, &domainnamelen, &peUse);

	wcout << "Owner: " << doname << " " << oname << " ";

	LookupAccountSid(NULL, sidgroup, oname, &namelen, doname, &domainnamelen, &peUse);
	wcout << "Group: " << doname << "/" << oname << "\n";

	wcout << "\n\n\n::DACL::" << "\n";
	SID *sid;
	unsigned long i, mask;
	char *stringsid;

	for (int i = 0; i<(*pdacl).AceCount; i++) {
		int c = 1;
		BOOL b = GetAce(pdacl, i, (PVOID*)&ace);

		//SID *sid = (SID *) ace->SidStart;
		if (((ACCESS_ALLOWED_ACE *)ace)->Header.AceType == ACCESS_ALLOWED_ACE_TYPE) {

			sid = (SID *)&((ACCESS_ALLOWED_ACE *)ace)->SidStart;
			LookupAccountSid(NULL, sid, oname, &namelen, doname, &domainnamelen, &peUse);
			wcout << "SID: " << doname << "/" << oname << "\n";
			mask = ((ACCESS_ALLOWED_ACE *)ace)->Mask;
		}
		else if (((ACCESS_DENIED_ACE *)ace)->Header.AceType == ACCESS_DENIED_ACE_TYPE) {
			sid = (SID *)&((ACCESS_DENIED_ACE *)ace)->SidStart;
			LookupAccountSid(NULL, sid, oname, &namelen, doname, &domainnamelen, &peUse);
			wcout << "SID: " << doname << "/" << oname << "\n";
			mask = ((ACCESS_DENIED_ACE *)ace)->Mask;
		}
		else printf("Other ACE\n");

		wcout << "ACE: mask:" << ace->Mask << " sidStart:" << ace->SidStart << " header type=" << (ace->Header.AceType ? "deny" : "allow") << " header flags=" << ace->Header.AceFlags << "\n";
		if (DELETE & ace->Mask) {
			wcout << " DELETE" << "\n";
		}
		if (FILE_GENERIC_READ & ace->Mask) {
			wcout << " FILE_GENERIC_READ" << "\n";
		}
		if (FILE_GENERIC_WRITE & ace->Mask) {
			wcout << " FILE_GENERIC_WRITE" << "\n";
		}
		if (FILE_GENERIC_EXECUTE & ace->Mask) {
			wcout << " FILE_GENERIC_EXECUTE" << "\n";
		}
		if (GENERIC_READ & ace->Mask) {
			wcout << " GENERIC_READ" << "\n";
		}
		if (GENERIC_WRITE & ace->Mask) {
			wcout << " GENERIC_WRITE" << "\n";
		}
		if (GENERIC_EXECUTE & ace->Mask) {
			wcout << " GENERIC_EXECUTE" << "\n";
		}
		if (GENERIC_ALL & ace->Mask) {
			wcout << " GENERIC_ALL" << "\n";
		}
		if (READ_CONTROL & ace->Mask) {
			wcout << " READ_CONTROL" << "\n";
		}
		if (WRITE_DAC & ace->Mask) {
			wcout << " WRITE_DAC" << "\n";
		}
		if (WRITE_OWNER & ace->Mask) {
			wcout << " WRITE_OWNER" << "\n";
		}
		if (SYNCHRONIZE & ace->Mask) {
			wcout << " SYNCHRONIZE" << "\n";
		}
		wcout << "\n";
	}
	/*
	SECURITY_DESCRIPTOR* p1 = (SECURITY_DESCRIPTOR*)psd;

	wcout << "\n\n\n::SECURITY_DESCRIPTOR_CONTROL::" << "\n";

	SECURITY_DESCRIPTOR_CONTROL ctrl = (*p1).Control;
	if (SE_OWNER_DEFAULTED & ctrl) {
		wcout << " SE_OWNER_DEFAULTED" << "\n";
	}
	if (SE_DACL_PRESENT & ctrl) {
		wcout << " SE_DACL_PRESENT" << "\n";
	}
	if (SE_DACL_DEFAULTED & ctrl) {
		wcout << " SE_DACL_DEFAULTED" << "\n";
	}
	if (SE_SACL_PRESENT & ctrl) {
		wcout << " SE_SACL_PRESENT" << "\n";
	}
	if (SE_SACL_DEFAULTED & ctrl) {
		wcout << " SE_SACL_DEFAULTED" << "\n";
	}
	if (SE_DACL_AUTO_INHERIT_REQ & ctrl) {
		wcout << " SE_DACL_AUTO_INHERIT_REQ" << "\n";
	}
	if (SE_SACL_AUTO_INHERIT_REQ & ctrl) {
		wcout << " SE_SACL_AUTO_INHERIT_REQ" << "\n";
	}
	if (SE_SACL_AUTO_INHERITED & ctrl) {
		wcout << " SE_SACL_AUTO_INHERITED" << "\n";
	}
	if (SE_DACL_PROTECTED & ctrl) {
		wcout << " SE_DACL_PROTECTED" << "\n";
	}
	if (SE_SACL_PROTECTED & ctrl) {
		wcout << " SE_SACL_PROTECTED" << "\n";
	}
	if (SE_RM_CONTROL_VALID & ctrl) {
		wcout << " SE_RM_CONTROL_VALID" << "\n";
	}
	if (SE_SELF_RELATIVE & ctrl) {
		wcout << " SE_SELF_RELATIVE" << "\n";
	}*/

	LocalFree(psd);
	LocalFree(sidowner);
	//LocalFree(pdacl);
	system("pause");
	return 0;
}