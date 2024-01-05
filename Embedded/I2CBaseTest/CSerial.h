#pragma once

#include "ArduinoString.h"

class CSerial
{
public:
	void print(const String& string);
	void println(const String& string);
};
