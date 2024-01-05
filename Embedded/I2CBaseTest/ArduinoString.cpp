#include <string>
#include <sstream>

#include "ArduinoString.h"


String::String()
	: m_data()
{}

String::String(const char* szData)
	: m_data(szData)
{}

String::String(const std::string& data)
	: m_data(data)
{}

String::String(const byte address, const EFormatFlags flags)
	: m_data()
{
	std::stringstream ss;
	switch (flags)
	{
	case HEX:
		ss << std::hex << address;
		break;
	case DEC:
	default:
		ss << address;
	}
	m_data = ss.str();
}

String String::operator+ (const String& rhs) const
{
	String result = m_data + rhs.m_data;
	return m_data;
}

void String::operator+= (const String& rhs)
{
	m_data += rhs.m_data;
}

char const* String::c_str() const
{
	return m_data.c_str();
}