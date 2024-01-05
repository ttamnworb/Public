#include <string>
#include <iostream>

#include "CSerial.h"


void CSerial::print(const String& string)
{
	std::cout << string.c_str();
}

void CSerial::println(const String& string)
{
	static const String LF("\n");
	this->print(string + LF);
}