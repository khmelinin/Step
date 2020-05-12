#pragma comment(linker,"\"/manifestdependency:type='win32' \
name='Microsoft.Windows.Common-Controls' version='6.0.0.0' \
processorArchitecture='*' publicKeyToken='6595b64144ccf1df' language='*'\"")

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
	wcl.style = CS_HREDRAW | CS_VREDRAW | CS_DBLCLKS; // CS (Class Style) - стиль окна
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

LRESULT CALLBACK WindowProc(HWND hWnd, UINT uMEssage, WPARAM wParam, LPARAM lParam)
{
	wchar_t str[50]=L"default"; // массив для изменения заголовка окна
	static int leftClick = 0; // счетчик кликов
	static int rightClick = 0; // счетчик кликов

	int xClick = LOWORD(lParam); // координата x для клика мышки
	int yClick = HIWORD(lParam); // координата y для клика мышки
	RECT rect; // структура для захвата координат окна
	GetClientRect(hWnd, &rect); // захват координат клиентской части окна

	int x = 0; // для смещения кнопки по x
	int y = 0; // для смещения кнопки по y

	std::list<LPCWSTR> messages = { L"OK?" }; // список сообщений для мэсседжбокса
	static HWND hButton; // кнопка OK

	static int score = 0;
	static int miss = 0;

	static HWND hButtonStop; // кнопка Stop
	switch (uMEssage)
	{
	case WM_CREATE:
	{
		//MessageBox(hWnd, L"Hello", L"OK", MB_ICONINFORMATION);
		hButton = CreateWindow(
			L"BUTTON",
			L"Game",
			WS_TABSTOP | WS_VISIBLE | WS_CHILD,
			300, 300,
			100, 100,
			hWnd,
			reinterpret_cast<HMENU>(1084), nullptr, nullptr,
			);
		hButtonStop = CreateWindow(
			L"BUTTON",
			L"Stop",
			WS_TABSTOP | WS_VISIBLE | WS_CHILD,
			0, 0,
			130, 100,
			hWnd,
			reinterpret_cast<HMENU>(1085), nullptr, nullptr,
			);
		break;
	}
	case WM_COMMAND:
	{
		switch (LOWORD(wParam))
		{
		case 1084:
			//MessageBox(hWnd, L"OK?", L"CLICK", MB_ICONINFORMATION);
			SetTimer(hWnd, 0, 700, NULL);
			score++;
			break;
		case 1085:
			wchar_t scoreCh[50]=L"";
			wsprintf(scoreCh, L"Score = %d , Missed = %d", score, miss);
			MessageBox(hWnd, scoreCh, L"Continue", MB_ICONINFORMATION);
			KillTimer(hWnd, false);
			score = 0;
			miss = 0;
			break;
	}
		break;
	}
	case WM_TIMER:
	{
		x = rand() % 800;
		y = rand() % 600;
		MoveWindow(hButton, x, y, 100, 100, true);
		break;
	}
	case WM_SIZE:
	{
		x = LOWORD(lParam);
		y = HIWORD(lParam);
		break;
	}
	case WM_LBUTTONDBLCLK:
	{
		leftClick+=2;
		/*
		for (auto msg : messages)
		{
			MessageBox(hWnd, msg, L"Resume", MB_ICONINFORMATION | MB_OK | MB_DEFBUTTON1);

		}
		*/
		break;
	}
	case WM_LBUTTONDOWN:
	{
		leftClick++;
		miss++;
		wsprintf(str, L"Count leftClick = %d", leftClick);
		break;
	}
	case WM_RBUTTONDOWN:
	{
		rightClick++;
		wsprintf(str, L"Count rightClick = %d", rightClick);
		/*
		if (xClick > rect.left + 50 && xClick < rect.right - 50 && yClick<rect.bottom && yClick>rect.top)
			wsprintf(str, L"IN");
		else
			wsprintf(str, L"OUT");
			*/
		break;
	}
	case WM_RBUTTONDBLCLK:
	{
		rightClick += 2;
	}

	case WM_DESTROY:
		PostQuitMessage(0);
		break;
	default:
		return DefWindowProc(hWnd, uMEssage, wParam, lParam);
	}
	//wsprintf(str, L"Count leftClick = %d", leftClick);
	SetWindowText(hWnd, str);
	return 0;
}