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