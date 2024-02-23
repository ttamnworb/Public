// SockGame1Dlg.h : header file
//

#if !defined(AFX_SOCKGAME1DLG_H__06422C65_D915_4751_8D37_C00C4AF48389__INCLUDED_)
#define AFX_SOCKGAME1DLG_H__06422C65_D915_4751_8D37_C00C4AF48389__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000

/////////////////////////////////////////////////////////////////////////////
// CSockGame1Dlg dialog

class CSockGame1Dlg : public CDialog
{
// Construction
public:
	CSockGame1Dlg(CWnd* pParent = NULL);	// standard constructor

// Dialog Data
	//{{AFX_DATA(CSockGame1Dlg)
	enum { IDD = IDD_SOCKGAME1_DIALOG };

	CButton	m_Sock01;
	CButton	m_Sock02;
	CButton	m_Sock03;
	CButton	m_Sock04;
	CButton	m_Sock05;
	CButton	m_Sock06;
	CButton	m_Sock07;
	CButton	m_Sock08;
	CButton	m_Sock09;
	CButton	m_Sock10;
	CButton	m_Sock11;
	CButton	m_Sock12;
	CButton	m_Sock13;
	CButton	m_Sock14;
	CButton	m_Sock15;
	CButton	m_Sock16;
	//}}AFX_DATA

	// ClassWizard generated virtual function overrides
	//{{AFX_VIRTUAL(CSockGame1Dlg)
	protected:
	virtual void DoDataExchange(CDataExchange* pDX);	// DDX/DDV support
	//}}AFX_VIRTUAL

// Implementation
protected:
	HICON m_hIcon;

	// Generated message map functions
	//{{AFX_MSG(CSockGame1Dlg)
	virtual BOOL OnInitDialog();
	afx_msg void OnSysCommand(UINT nID, LPARAM lParam);
	afx_msg void OnPaint();
	afx_msg HCURSOR OnQueryDragIcon();
	afx_msg void OnOK();
	afx_msg void OnCancel();
	afx_msg void OnButton1(){ClickOn(1);};
	afx_msg void OnButton2(){ClickOn(2);};
	afx_msg void OnButton3(){ClickOn(3);};
	afx_msg void OnButton4(){ClickOn(4);};
	afx_msg void OnButton5(){ClickOn(5);};
	afx_msg void OnButton6(){ClickOn(6);};
	afx_msg void OnButton7(){ClickOn(7);};
	afx_msg void OnButton8(){ClickOn(8);};
	afx_msg void OnButton9(){ClickOn(9);};
	afx_msg void OnButton10(){ClickOn(10);};
	afx_msg void OnButton11(){ClickOn(11);};
	afx_msg void OnButton12(){ClickOn(12);};
	afx_msg void OnButton13(){ClickOn(13);};
	afx_msg void OnButton14(){ClickOn(14);};
	afx_msg void OnButton15(){ClickOn(15);};
	afx_msg void OnButton16(){ClickOn(16);};
	afx_msg void OnCheat();
	//}}AFX_MSG
	DECLARE_MESSAGE_MAP()
private:
	void ClickOn(int button);
	void DrawSock (int button);
	void UndrawSock (int button, bool beforeDestroy = false);
	void ShuffleSocks(void);

private:
	void Intialise();
	int oneSockSelected;
	bool sockIsShown[16];
	bool sockIsMatched[16];
	HBITMAP socks[8];
	HBITMAP backImage;
	int sockPosition[16];
	CButton* theButtons[16];
};

//{{AFX_INSERT_LOCATION}}
// Microsoft Visual C++ will insert additional declarations immediately before the previous line.

#endif // !defined(AFX_SOCKGAME1DLG_H__06422C65_D915_4751_8D37_C00C4AF48389__INCLUDED_)

