#pragma once
#include <string>

typedef unsigned char byte;

enum EFormatFlags
{
	DEC, 
	HEX, 
	BIN
};

class String
{
public:
	String();
	String(const char* szData);
	String(const std::string& data);
	String(const byte address, const EFormatFlags flags);

	String operator+ (const String& rhs) const;
	void operator+= (const String& rhs);

	char const* c_str() const;

private:
	std::string m_data;
};

