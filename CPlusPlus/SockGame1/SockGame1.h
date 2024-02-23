// SockGame1.h : main header file for the SOCKGAME1 application
//

#if !defined(AFX_SOCKGAME1_H__E34B7518_FD89_4919_B063_176820DE9DB7__INCLUDED_)
#define AFX_SOCKGAME1_H__E34B7518_FD89_4919_B063_176820DE9DB7__INCLUDED_

#if _MSC_VER > 1000
#pragma once
#endif // _MSC_VER > 1000

#ifndef __AFXWIN_H__
	#error include 'stdafx.h' before including this file for PCH
#endif

#include "resource.h"		// main symbols

/////////////////////////////////////////////////////////////////////////////
// CSockGame1App:
// See SockGame1.cpp for the implementation of this class
//

class CSockGame1App : public CWinApp
{
public:
	CSockGame1App();

// Overrides
	// ClassWizard generated virtual function overrides
	//{{AFX_VIRTUAL(CSockGame1App)
	public:
	virtual BOOL InitInstance();
	//}}AFX_VIRTUAL

// Implementation

	//{{AFX_MSG(CSockGame1App)
		// NOTE - the ClassWizard will add and remove member functions here.
		//    DO NOT EDIT what you see in these blocks of generated code !
	//}}AFX_MSG
	DECLARE_MESSAGE_MAP()
};


/////////////////////////////////////////////////////////////////////////////

//{{AFX_INSERT_LOCATION}}
// Microsoft Visual C++ will insert additional declarations immediately before the previous line.

#endif // !defined(AFX_SOCKGAME1_H__E34B7518_FD89_4919_B063_176820DE9DB7__INCLUDED_)
