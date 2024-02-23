// SockGame1Dlg.cpp : implementation file
//

#include "stdafx.h"
#include "resource.h"
#include "SockGame1.h"
#include "SockGame1Dlg.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif

/////////////////////////////////////////////////////////////////////////////
// CAboutDlg dialog used for App About

class CAboutDlg : public CDialog
{
public:
	CAboutDlg();

// Dialog Data
	//{{AFX_DATA(CAboutDlg)
	enum { IDD = IDD_ABOUTBOX };
	//}}AFX_DATA

	// ClassWizard generated virtual function overrides
	//{{AFX_VIRTUAL(CAboutDlg)
	protected:
	virtual void DoDataExchange(CDataExchange* pDX);    // DDX/DDV support
	//}}AFX_VIRTUAL

// Implementation
protected:
	//{{AFX_MSG(CAboutDlg)
	//}}AFX_MSG
	DECLARE_MESSAGE_MAP()
};

CAboutDlg::CAboutDlg() : CDialog(CAboutDlg::IDD)
{
	//{{AFX_DATA_INIT(CAboutDlg)
	//}}AFX_DATA_INIT
}

void CAboutDlg::DoDataExchange(CDataExchange* pDX)
{
	CDialog::DoDataExchange(pDX);
	//{{AFX_DATA_MAP(CAboutDlg)
	//}}AFX_DATA_MAP
}

BEGIN_MESSAGE_MAP(CAboutDlg, CDialog)
	//{{AFX_MSG_MAP(CAboutDlg)
		// No message handlers
	//}}AFX_MSG_MAP
END_MESSAGE_MAP()

/////////////////////////////////////////////////////////////////////////////
// CSockGame1Dlg dialog

CSockGame1Dlg::CSockGame1Dlg(CWnd* pParent /*=NULL*/)
	: CDialog(CSockGame1Dlg::IDD, pParent)
{
	//{{AFX_DATA_INIT(CSockGame1Dlg)
	//}}AFX_DATA_INIT
	// Note that LoadIcon does not require a subsequent DestroyIcon in Win32
	m_hIcon = AfxGetApp()->LoadIcon(IDR_MAINFRAME);
}

void CSockGame1Dlg::DoDataExchange(CDataExchange* pDX)
{
	CDialog::DoDataExchange(pDX);
	//{{AFX_DATA_MAP(CSockGame1Dlg)
	DDX_Control(pDX, IDC_BUTTON9, m_Sock09);
	DDX_Control(pDX, IDC_BUTTON8, m_Sock08);
	DDX_Control(pDX, IDC_BUTTON7, m_Sock07);
	DDX_Control(pDX, IDC_BUTTON6, m_Sock06);
	DDX_Control(pDX, IDC_BUTTON5, m_Sock05);
	DDX_Control(pDX, IDC_BUTTON4, m_Sock04);
	DDX_Control(pDX, IDC_BUTTON3, m_Sock03);
	DDX_Control(pDX, IDC_BUTTON2, m_Sock02);
	DDX_Control(pDX, IDC_BUTTON16, m_Sock16);
	DDX_Control(pDX, IDC_BUTTON15, m_Sock15);
	DDX_Control(pDX, IDC_BUTTON14, m_Sock14);
	DDX_Control(pDX, IDC_BUTTON13, m_Sock13);
	DDX_Control(pDX, IDC_BUTTON12, m_Sock12);
	DDX_Control(pDX, IDC_BUTTON11, m_Sock11);
	DDX_Control(pDX, IDC_BUTTON10, m_Sock10);
	DDX_Control(pDX, IDC_BUTTON1, m_Sock01);
	//}}AFX_DATA_MAP
}

BEGIN_MESSAGE_MAP(CSockGame1Dlg, CDialog)
	//{{AFX_MSG_MAP(CSockGame1Dlg)
	ON_WM_SYSCOMMAND()
	ON_WM_PAINT()
	ON_WM_QUERYDRAGICON()
	ON_BN_CLICKED(IDC_BUTTON1, OnButton1)
	ON_BN_CLICKED(IDC_BUTTON2, OnButton2)
	ON_BN_CLICKED(IDC_BUTTON3, OnButton3)
	ON_BN_CLICKED(IDC_BUTTON4, OnButton4)
	ON_BN_CLICKED(IDC_BUTTON5, OnButton5)
	ON_BN_CLICKED(IDC_BUTTON6, OnButton6)
	ON_BN_CLICKED(IDC_BUTTON7, OnButton7)
	ON_BN_CLICKED(IDC_BUTTON8, OnButton8)
	ON_BN_CLICKED(IDC_BUTTON9, OnButton9)
	ON_BN_CLICKED(IDC_BUTTON10, OnButton10)
	ON_BN_CLICKED(IDC_BUTTON11, OnButton11)
	ON_BN_CLICKED(IDC_BUTTON12, OnButton12)
	ON_BN_CLICKED(IDC_BUTTON13, OnButton13)
	ON_BN_CLICKED(IDC_BUTTON14, OnButton14)
	ON_BN_CLICKED(IDC_BUTTON15, OnButton15)
	ON_BN_CLICKED(IDC_BUTTON16, OnButton16)
	ON_BN_CLICKED(IDC_CHEAT, OnCheat)
	//}}AFX_MSG_MAP
END_MESSAGE_MAP()

/////////////////////////////////////////////////////////////////////////////
// CSockGame1Dlg message handlers

BOOL CSockGame1Dlg::OnInitDialog()
{
	CDialog::OnInitDialog();

	// Add "About..." menu item to system menu.

	// IDM_ABOUTBOX must be in the system command range.
	ASSERT((IDM_ABOUTBOX & 0xFFF0) == IDM_ABOUTBOX);
	ASSERT(IDM_ABOUTBOX < 0xF000);

	CMenu* pSysMenu = GetSystemMenu(FALSE);
	if (pSysMenu != NULL)
	{
		CString strAboutMenu;
		strAboutMenu.LoadString(IDS_ABOUTBOX);
		if (!strAboutMenu.IsEmpty())
		{
			pSysMenu->AppendMenu(MF_SEPARATOR);
			pSysMenu->AppendMenu(MF_STRING, IDM_ABOUTBOX, strAboutMenu);
		}
	}

	// Set the icon for this dialog.  The framework does this automatically
	//  when the application's main window is not a dialog
	SetIcon(m_hIcon, TRUE);			// Set big icon
	SetIcon(m_hIcon, FALSE);		// Set small icon
	
	// TODO: Add extra initialization here
	
	return TRUE;  // return TRUE  unless you set the focus to a control
}

void CSockGame1Dlg::OnSysCommand(UINT nID, LPARAM lParam)
{
	if ((nID & 0xFFF0) == IDM_ABOUTBOX)
	{
		CAboutDlg dlgAbout;
		dlgAbout.DoModal();
	}
	else
	{
		CDialog::OnSysCommand(nID, lParam);
	}
}

// If you add a minimize button to your dialog, you will need the code below
//  to draw the icon.  For MFC applications using the document/view model,
//  this is automatically done for you by the framework.

void CSockGame1Dlg::OnPaint() 
{
	if (IsIconic())
	{
		CPaintDC dc(this); // device context for painting

		SendMessage(WM_ICONERASEBKGND, (WPARAM) dc.GetSafeHdc(), 0);

		// Center icon in client rectangle
		int cxIcon = GetSystemMetrics(SM_CXICON);
		int cyIcon = GetSystemMetrics(SM_CYICON);
		CRect rect;
		GetClientRect(&rect);
		int x = (rect.Width() - cxIcon + 1) / 2;
		int y = (rect.Height() - cyIcon + 1) / 2;

		// Draw the icon
		dc.DrawIcon(x, y, m_hIcon);
	}
	else
	{
		CDialog::OnPaint();
	}
}

// The system calls this to obtain the cursor to display while the user drags
//  the minimized window.
HCURSOR CSockGame1Dlg::OnQueryDragIcon()
{
	return (HCURSOR) m_hIcon;
}

void CSockGame1Dlg::OnOK() 
{
	// Start a new game.
	Intialise();
	UndrawSock(-1);			// Undraw all buttons.
	ShuffleSocks();			// Shuffle them all.
}

void CSockGame1Dlg::OnCancel()
{
//	UndrawSock(-1, true);
	for (int i = 0; i < 8; i++)
		DeleteObject((HGDIOBJ)socks[i]);
	DeleteObject((HGDIOBJ)backImage);
//	CDialog::OnCancel();
	exit(1);
}


//
// When a button is clicked on.
//
void CSockGame1Dlg::ClickOn(int button)
{
	bool gameOver = true;

	if (sockIsMatched[button-1]  || oneSockSelected == (button-1))
	{
		::MessageBeep(-1);
	}
	else
	{
		if (oneSockSelected > -1)
		{
			DrawSock(button-1);
			// Test for a match
			if (sockPosition[oneSockSelected] == sockPosition[button-1])
			{	// We have a match.
				::MessageBeep(MB_ICONEXCLAMATION);
				sockIsMatched[button-1] = true;
				sockIsMatched[oneSockSelected] = true;
				for (int i = 0; i < 16; i++)
					gameOver &= sockIsMatched[i];
				if (gameOver)
				{
					::MessageBeep(MB_ICONASTERISK);
					::MessageBox (NULL, "Congratulations you won the sock pairing game", "Yipee", MB_OK);
					OnOK();
				}
			}
			else
			{	// No match.
				Sleep (2000);
				UndrawSock (button-1);
				UndrawSock (oneSockSelected);
			}
			oneSockSelected = -1;
		}
		else
		{
			DrawSock(button-1);
			oneSockSelected = button-1;
		}
	}
}

//
// Shuffle the order of the socks.
//
void CSockGame1Dlg::ShuffleSocks()
{
	int i = 0;
	int a;
	bool unset;

	srand( (unsigned)time( NULL ) );
	oneSockSelected = -1;
	for (i = 0; i < 16; i++)
	{
		sockIsShown[i] = false;
		sockIsMatched[i] = false;
		sockPosition[i] = -1;
	}
	for (i = 0; i < 8; i++)
	{
		unset = true;
		while (unset)
		{
			a = rand() % 16;
			if (sockPosition[a] == -1)
			{
				sockPosition[a] = i;
				unset = false;
			}
		}
		unset = true;
		while (unset)
		{
			a = rand() % 16;
			if (sockPosition[a] == -1)
			{
				sockPosition[a] = i;
				unset = false;
			}
		}
	}
}

//
// Undraw a button.
//
void CSockGame1Dlg::UndrawSock(int button, bool beforeDestroy)
{
	if (button < 0)
	{
		for (int i = 0; i < 16; i++)
		{
			UndrawSock(i);
		}
	}
	else
	{
//		if (!beforeDestroy)
		{
			theButtons[button]->SetBitmap (backImage);
			RedrawWindow();
		}
//		else
//			theButtons[button]->SetBitmap(NULL);
	}
}

//
// Draw button
//
void CSockGame1Dlg::DrawSock(int button)
{
	if (button < 0)
	{
		for (int i = 0; i < 16; i++)
		{
			DrawSock(i);
		}
	}
	else
	{
		theButtons[button]->SetBitmap (socks[sockPosition[button]]);
		RedrawWindow();
	}
}

void CSockGame1Dlg::Intialise()
{
	theButtons[0] = &m_Sock01;
	theButtons[1] = &m_Sock02;
	theButtons[2] = &m_Sock03;
	theButtons[3] = &m_Sock04;
	theButtons[4] = &m_Sock05;
	theButtons[5] = &m_Sock06;
	theButtons[6] = &m_Sock07;
	theButtons[7] = &m_Sock08;
	theButtons[8] = &m_Sock09;
	theButtons[9] = &m_Sock10;
	theButtons[10] = &m_Sock11;
	theButtons[11] = &m_Sock12;
	theButtons[12] = &m_Sock13;
	theButtons[13] = &m_Sock14;
	theButtons[14] = &m_Sock15;
	theButtons[15] = &m_Sock16;

	// Load the bitmaps. 
	backImage = LoadBitmap(AfxGetInstanceHandle(), MAKEINTRESOURCE(IDB_BACKIMAGE));
	socks[0] = LoadBitmap(AfxGetInstanceHandle(), MAKEINTRESOURCE(IDB_SOCK1));
	socks[1] = LoadBitmap(AfxGetInstanceHandle(), MAKEINTRESOURCE(IDB_SOCK2));
	socks[2] = LoadBitmap(AfxGetInstanceHandle(), MAKEINTRESOURCE(IDB_SOCK3));
	socks[3] = LoadBitmap(AfxGetInstanceHandle(), MAKEINTRESOURCE(IDB_SOCK4));
	socks[4] = LoadBitmap(AfxGetInstanceHandle(), MAKEINTRESOURCE(IDB_SOCK5));
	socks[5] = LoadBitmap(AfxGetInstanceHandle(), MAKEINTRESOURCE(IDB_SOCK6));
	socks[6] = LoadBitmap(AfxGetInstanceHandle(), MAKEINTRESOURCE(IDB_SOCK7));
	socks[7] = LoadBitmap(AfxGetInstanceHandle(), MAKEINTRESOURCE(IDB_SOCK8));

}

void CSockGame1Dlg::OnCheat() 
{
	DrawSock(-1);
	for (int i = 0; i < 16; i++)
		sockIsMatched[i] = true;	
}
