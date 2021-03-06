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
	wcl.style = CS_HREDRAW | CS_VREDRAW; // CS (Class Style) - ����� ����
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
	std::list<LPCWSTR> messages = { L"OK?",L"OK?", L"OK?" };
	switch (uMEssage)
	{
	case WM_LBUTTONDOWN:
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