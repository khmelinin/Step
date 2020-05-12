#pragma comment(linker,"\"/manifestdependency:type='win32' \
name='Microsoft.Windows.Common-Controls' version='6.0.0.0' \
processorArchitecture='*' publicKeyToken='6595b64144ccf1df' language='*'\"")

#include <Windows.h>
#include <string>
#include <list>

// ���������� - ���������� �����, ������� Windows ���������� ��� �������������. ���� ����� ������ ����� ������������(����, ����, ����, �������, ���������� ����� � �.�.).

// �������� ��� ������� ���������
LRESULT CALLBACK WindowProc(HWND, UINT, WPARAM, LPARAM);

// ��� ������ ����
TCHAR szClassWindow[] = TEXT("First application.");

INT WINAPI WinMain(HINSTANCE hInst, HINSTANCE hPrevInst, LPSTR lpszCmdLine, int nCmdShow)
{
	HWND hWnd;
	MSG lpMsg;
	WNDCLASSEX wcl;

	// 1. ����������� ������ ����
	wcl.cbSize = sizeof(wcl); // ������ ��������� WNDCLASSEX
	// ������������ ����, ���� ���������� �� ����������� ��� �� ���������
	wcl.style = CS_HREDRAW | CS_VREDRAW | CS_DBLCLKS; // CS (Class Style) - ����� ����
	wcl.lpfnWndProc;
	wcl.lpfnWndProc = WindowProc; // ����� ������� ���������
	wcl.cbClsExtra = 0; // used by Windows
	wcl.cbWndExtra = 0; // used by Windows
	wcl.hInstance = hInst; // ���������� ������� ����������
	wcl.hIcon = LoadIcon(NULL, IDI_APPLICATION); // ������ ����������
	wcl.hCursor = LoadCursor(NULL, IDC_ARROW); // �������� ������������ �������
	wcl.hbrBackground = (HBRUSH)GetStockObject(WHITE_BRUSH); // ���������� ���� ����� ������
	wcl.lpszMenuName = NULL; // ���������� �� �������� ����
	wcl.lpszClassName = szClassWindow; // ��� ������ ����
	wcl.hIconSm = NULL; // ���������� ��������� ������ ��� ����� � ������� ����

	// 2. ����������� ������ ����
	if (!RegisterClassEx(&wcl))
		return 0; // ��� ��������� ����������� - �����

	// 3. �������� ����

	// ������� ���� � ���������� hWnd ����������� ���������� ����
	hWnd = CreateWindowEx(
		0, // ����������� ����� ����
		szClassWindow, // ��� ������ ����
		TEXT("������ Windows ����������"), // ��������� ����
		WS_OVERLAPPEDWINDOW, // ����� ����
		// ���������, �����, ����������� ������ �������, ��������� ����, ������ ������������ � �������������
		CW_USEDEFAULT, // x - ���������� ������ �������� ���� ����
		CW_USEDEFAULT, // y - ���������� ������ �������� ���� ����
		CW_USEDEFAULT, // ������ ����
		CW_USEDEFAULT, // ������ ����
		NULL, // ���������� ������������� ����
		NULL, // ���������� ���� ����
		hInst, // ������������� ����������, ������� ������� ����
		NULL // ��������� �� ������� ������ ����������
	);

	// 4. ����������� ����
	ShowWindow(hWnd, nCmdShow);
	UpdateWindow(hWnd); // ����������� ����

	// 5. ���� ��������� ����������
	while (GetMessage(&lpMsg, NULL, 0, 0)) // ��������� ��������� �� ������� ���������
	{
		TranslateMessage(&lpMsg);
		DispatchMessage(&lpMsg);
	}
	return lpMsg.wParam; // ������� ����

}

LRESULT CALLBACK WindowProc(HWND hWnd, UINT uMEssage, WPARAM wParam, LPARAM lParam)
{
	wchar_t str[50]=L"default"; // ������ ��� ��������� ��������� ����
	static int leftClick = 0; // ������� ������
	static int rightClick = 0; // ������� ������

	int xClick = LOWORD(lParam); // ���������� x ��� ����� �����
	int yClick = HIWORD(lParam); // ���������� y ��� ����� �����
	RECT rect; // ��������� ��� ������� ��������� ����
	GetClientRect(hWnd, &rect); // ������ ��������� ���������� ����� ����

	int x = 0; // ��� �������� ������ �� x
	int y = 0; // ��� �������� ������ �� y

	std::list<LPCWSTR> messages = { L"OK?" }; // ������ ��������� ��� ������������
	static HWND hButton; // ������ OK

	static int score = 0;
	static int miss = 0;

	static HWND hButtonStop; // ������ Stop
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