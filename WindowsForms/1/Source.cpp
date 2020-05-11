#define _CRT_SECURE_NO_WARNINGS
#include <iostream>
#include <Windows.h>
using namespace std;

int main()
{
	/*
	// ANSI
	char szBuf[15] = "The ";
	strcat(szBuf, "World!");
	cout << sizeof(szBuf) << " bytes" << endl;

	// UNICODE
	wchar_t szBuf1[15] = L"The ";
	wcscat(szBuf1, L"World!");
	cout << sizeof(szBuf1) << " bytes" << endl;
	*/


	// UINT - unsigned int
	// DWORD - unsigned long
	//LPCSTR - long pointer const str
	//LPWSTR - long pointer wide str

	/*
	int MultiByteToWideChar(
		UINT CodePage, // code page
		DWORD dwFlags, // addition options for letter conversion
		LPCSTR lpMultiByteStr, // pointer to conversed string
		int cbMultiByte, // sizeof(str) in bytes
		LPWSTR lpWideCharStr, // pointer to buffer where we want to write UNICODE string
		int ccWideChar // size of buffer
	);
	*/

	// ANSI tp Unicode
	/*
	char buffer[] = "MultiByteToWideChar converts ANSI to UNICODE.";
	int length = MultiByteToWideChar(CP_ACP , 0, buffer, -1, NULL, 0);
	wchar_t* ptr = new wchar_t[length];
	MultiByteToWideChar(CP_ACP, 0, buffer, -1, ptr, length);
	wcout << ptr << endl;
	cout << "Length unicode = " << wcslen(ptr) << endl;
	cout << "Length allocated memory = " << _msize(ptr) << endl;
	delete[]ptr;


	// C/C++ Runtime Library
	
	char buffer1[] = "mbstowcs convert ANSI to UNICODE.";
	int length1 = mbstowcs(NULL, buffer1, 0);
	wchar_t* ptr1 = new wchar_t[length1];
	mbstowcs(ptr1, buffer1, length1);
	cout << "\nLength unicode = " << length1 << endl;
	wcout << "Size allocated memory = " << _msize(ptr1) << endl;
	delete[]ptr1;
	*/

	// UNICODE to ANSI
	/*
	int WideCharToMultiByte(
		UINT CodePage, // code page
		DWORD dwFlags, // addition options for letter conversion
		LPWSTR lpWideCharStr, // pointer to buffer where we want
		int ccWideCharsStr, // amount of chars in string
		LPSTR lpMultiByteStr, // pointer to buffer where we want to write ANSI string
		int cbMultiByte, // size of buffer
		LPCCH lpDefaultChar, // use default symbol if this will not be founded
		LPBOOL lpUsedDefaultChar, // pointer to succesfull conversion
	)
	*/

	wchar_t buffer[] = L"WideCharToMultiByte converts Unicode to ANSI";
	int length = WideCharToMultiByte(CP_ACP, 0, buffer, -1, NULL, 0, 0, 0);

	char* ptr = new char[length];
	WideCharToMultiByte(CP_ACP, 0, buffer, -1, ptr, length, 0, 0);
	cout << ptr << endl;
	cout << "Length of ANSI string = " << strlen(ptr) << endl;
	cout << "Size of allocated memory = " << _msize(ptr) << endl;

	delete[]ptr;

	// C/C++ Runtime Library
	wchar_t buffer1[] = L"wcstombs converts Unicode to ANSI";
	int length1 = wcstombs(NULL, buffer1, 0);
	char* ptr1 = new char[length1+1];

	wcstombs(ptr1, buffer1, length1+1);
	cout << endl << ptr1 << endl;
	cout << "Length of ANSI string = " << strlen(ptr1) << endl;
	cout << "Size of allocated memory = " << _msize(ptr1) << endl;

	delete[] ptr1;
}