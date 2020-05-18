#include <Windows.h>
#include <string>
#include <list>

// ƒескриптор - уникальное число, которое Windows использует дл€ идентификации. ≈сть много разных типов дескрипторов(окно, меню, файл, контрол, устройства ввода и т.д.).

// прототип дл€ оконной процедуры
LRESULT CALLBACK WindowProc(HWND, UINT, WPARAM, LPARAM);

// »м€ класса окна
TCHAR szClassWindow[] = TEXT("First application.");

INT WINAPI WinMain(HINSTANCE hInst, HINSTANCE hPrevInst, LPSTR lpszCmdLine, int nCmdShow)
{
	HWND hWnd;
	MSG lpMsg;
	WNDCLASSEX wcl;

	// 1. ќпределение класса окна
	wcl.cbSize = sizeof(wcl); // размер структуры WNDCLASSEX
	// ѕерерисовать окно, если изменитьс€ по горизонтали или по вертикали
	wcl.style = CS_HREDRAW | CS_VREDRAW; // CS (Class Style) - стиль окна
	wcl.lpfnWndProc;
	wcl.lpfnWndProc = WindowProc; // адрес оконной процедуры
	wcl.cbClsExtra = 0; // used by Windows
	wcl.cbWndExtra = 0; // used by Windows
	wcl.hInstance = hInst; // дескриптор данного приложени€
	wcl.hIcon = LoadIcon(NULL, IDI_APPLICATION); // иконка приложени€
	wcl.hCursor = LoadCursor(NULL, IDC_ARROW); // загрузка стандартного курсора
	wcl.hbrBackground = (HBRUSH)GetStockObject(WHITE_BRUSH); // заполнение окна белым цветом
	wcl.lpszMenuName = NULL; // приложение не содержит меню
	wcl.lpszClassName = szClassWindow; // им€ класса окна
	wcl.hIconSm = NULL; // отсутствие маленькой иконки дл€ св€зи с классом окна

	// 2. –егистраци€ класса окна
	if (!RegisterClassEx(&wcl))
		return 0; // при неудачной регистрации - выход

	// 3. —оздание окна

	// создаем окно и переменной hWnd присваиваем дескриптор окна
	hWnd = CreateWindowEx(
		0, // расширинный стиль окна
		szClassWindow, // им€ класса окна
		TEXT(" аркас Windows приложени€"), // заголовок окна
		WS_OVERLAPPEDWINDOW, // стиль окна
		// заголовок, рамка, позвол€юща€ мен€ть размеры, системное меню, кнопки сворачивани€ и развертывани€
		CW_USEDEFAULT, // x - координата левого верхнего угла окна
		CW_USEDEFAULT, // y - координата левого верхнего угла окна
		CW_USEDEFAULT, // ширина окна
		CW_USEDEFAULT, // высота окна
		NULL, // дескриптор родительского окна
		NULL, // дескриптор меню окна
		hInst, // идентификатор приложени€, которое создало окно
		NULL // указатель на область данных приложени€
	);

	// 4. ќтображение окна
	ShowWindow(hWnd, nCmdShow);
	UpdateWindow(hWnd); // перерисовка окна

	// 5. ÷икл обработки исключений
	while (GetMessage(&lpMsg, NULL, 0, 0)) // получение сообщени€ из очереди сообщений
	{
		TranslateMessage(&lpMsg);
		DispatchMessage(&lpMsg);
	}
	return lpMsg.wParam; // старший байт

}

LRESULT CALLBACK WindowProc(HWND hWnd, UINT uMEssage, WPARAM wParam, LPARAM lParam)
{
	wchar_t resume1[150] = L"Skills \nSoft skills :\nProblem - solving\nCreative thinking\nHard skills : \nPython, C# and Java\nJenkinsand Ansible\nSelenium\nAWS cloud knowledge";
	wchar_t resume2[256] = L"Stable Software Solutions\nDevOps Engineer\nEnd date : PresentResponsibilities:\nPart of a 10 - person team that developed a CI / CD pipeline and cut software release times by 50 % with a 15 % increase in customer satisfaction";
	wchar_t resume3[100] = L"Used Selenium to develop a series of new automated software tests that cut QA overheads by $5,000";
	wchar_t resume4[256] = L"Helped make the company's development, testing and production environments more consistent by implementing container technology using Kubernetes\nProactively identified and resolved performance bottlenecks for a new application before it went to production";
	char count[26];
	_gcvt_s(count, sizeof(count), (wcslen(resume1) + wcslen(resume2) + wcslen(resume3) + wcslen(resume4)) / 4, 17);
	int length = MultiByteToWideChar(CP_ACP, 0, count, -1, NULL, 0);
	wchar_t *wcount=new wchar_t[length];
	
	MultiByteToWideChar(CP_ACP, 0, count, -1, wcount, length);


	std::list<LPCWSTR> messages = { resume1, resume2, resume3, resume4, wcount };
	switch (uMEssage)
	{
	case WM_CREATE:
	{
		for (auto msg : messages)
		{
			MessageBox(hWnd, msg, L"Resume", MB_ICONINFORMATION | MB_OK | MB_DEFBUTTON1);

		}
		break;
	}
	case WM_DESTROY:
		PostQuitMessage(0);
		break;
	default:
		return DefWindowProc(hWnd, uMEssage, wParam, lParam);
	}
	return 0;
}