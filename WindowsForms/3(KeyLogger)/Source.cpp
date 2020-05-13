#include <Windows.h>
#include <string>
#include <list>

// Дескриптор - уникальное число, которое Windows использует для идентификации. Есть много разных типов дескрипторов(окно, меню, файл, контрол, устройства ввода и т.д.).

// прототип для оконной процедуры
LRESULT CALLBACK WindowProc(HWND, UINT, WPARAM, LPARAM);

// Имя класса окна
TCHAR szClassWindow[] = TEXT("First application.");

INT WINAPI WinMain(HINSTANCE hInst, HINSTANCE hPrevInst, LPSTR lpszCmdLine, int nCmdShow)
{
	HWND hWnd;
	MSG lpMsg;
	WNDCLASSEX wcl;

	// 1. Определение класса окна
	wcl.cbSize = sizeof(wcl); // размер структуры WNDCLASSEX
	// Перерисовать окно, если измениться по горизонтали или по вертикали
	wcl.style = CS_HREDRAW | CS_VREDRAW; // CS (Class Style) - стиль окна
	wcl.lpfnWndProc;
	wcl.lpfnWndProc = WindowProc; // адрес оконной процедуры
	wcl.cbClsExtra = 0; // used by Windows
	wcl.cbWndExtra = 0; // used by Windows
	wcl.hInstance = hInst; // дескриптор данного приложения
	wcl.hIcon = LoadIcon(NULL, IDI_APPLICATION); // иконка приложения
	wcl.hCursor = LoadCursor(NULL, IDC_ARROW); // загрузка стандартного курсора
	wcl.hbrBackground = (HBRUSH)GetStockObject(WHITE_BRUSH); // заполнение окна белым цветом
	wcl.lpszMenuName = NULL; // приложение не содержит меню
	wcl.lpszClassName = szClassWindow; // имя класса окна
	wcl.hIconSm = NULL; // отсутствие маленькой иконки для связи с классом окна

	// 2. Регистрация класса окна
	if (!RegisterClassEx(&wcl))
		return 0; // при неудачной регистрации - выход

	// 3. Создание окна

	// создаем окно и переменной hWnd присваиваем дескриптор окна
	hWnd = CreateWindowEx(
		0, // расширинный стиль окна
		szClassWindow, // имя класса окна
		TEXT("Каркас Windows приложения"), // заголовок окна
		WS_OVERLAPPEDWINDOW, // стиль окна
		// заголовок, рамка, позволяющая менять размеры, системное меню, кнопки сворачивания и развертывания
		CW_USEDEFAULT, // x - координата левого верхнего угла окна
		CW_USEDEFAULT, // y - координата левого верхнего угла окна
		CW_USEDEFAULT, // ширина окна
		CW_USEDEFAULT, // высота окна
		NULL, // дескриптор родительского окна
		NULL, // дескриптор меню окна
		hInst, // идентификатор приложения, которое создало окно
		NULL // указатель на область данных приложения
	);

	// 4. Отображение окна
	ShowWindow(hWnd, nCmdShow);
	UpdateWindow(hWnd); // перерисовка окна

	// 5. Цикл обработки исключений
	while (GetMessage(&lpMsg, NULL, 0, 0)) // получение сообщения из очереди сообщений
	{
		TranslateMessage(&lpMsg);
		DispatchMessage(&lpMsg);
	}
	return lpMsg.wParam; // старший байт

}

VOID CALLBACK MyTimerProc(
	HWND hWnd,
	UINT uMessage,
	UINT idTimer, // идентификатор таймера
	DWORD dwTimer // текущее время системы
	)
{
	RECT lpRect;
	GetWindowRect(hWnd, &lpRect);
	MoveWindow(hWnd, lpRect.left + 50, lpRect.top, 300, 300, true);
	
	
}

LRESULT CALLBACK WindowProc(HWND hWnd, UINT uMEssage, WPARAM wParam, LPARAM lParam)
{
	wchar_t str[50];
	switch (uMEssage)
	{
	case WM_CHAR: // получает все сообщения с вводом символов
		RECT lpDesctop;
		GetWindowRect(GetDesktopWindow(), &lpDesctop);
		wsprintf(str, L"%d", lpDesctop.right);
		SetWindowText(hWnd, str);
		break;
	case WM_LBUTTONDOWN:
		SetTimer(hWnd, 27, 500, MyTimerProc);
		break;
	case WM_RBUTTONDOWN:
		KillTimer(hWnd, 27);
		break;
	case WM_DESTROY:
		PostQuitMessage(0);
		break;
	default:
		return DefWindowProc(hWnd, uMEssage, wParam, lParam);
	}
	return 0;
}