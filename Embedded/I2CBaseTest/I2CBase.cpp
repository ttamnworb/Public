// I2CBase
// Base class supporting multiple I2C devices.
// Matt 01/09/2016

#ifndef TwoWire_h
#include <Wire.h>
#endif

#include "I2CBase.h"

// Class constructor, can be used as an alternative to begin
I2CBase::I2CBase(const byte address)
	: m_ModuleAddress(address)
{
	logDebug(m_ModuleAddress, "constructor called");
}

// Alternative to the constructor.
void I2CBase::begin(const byte address)
{
	m_ModuleAddress = address;
	logDebug(m_ModuleAddress, "begin() called");
}

// Write a single byte to the bus.
void I2CBase::writeByte(const byte address, const byte value)
{
	Wire.beginTransmission(address);
	Wire.write(value);
	Wire.endTransmission();
}

// Write a value to a register
void I2CBase::writeRegister(const byte address, const byte regAddress, const byte value)
{
	logDebug(address, false, regAddress, value);

	Wire.beginTransmission(address);
	Wire.write(regAddress);
	Wire.write(value);
	Wire.endTransmission();
}

// Read a value from a register
byte I2CBase::readRegister(const byte address, const byte regAddress)
{
	logDebug(address, true, regAddress, 0);

	static const uint8_t dataSize = 1;
	Wire.beginTransmission(address);
	Wire.write(regAddress);
	Wire.endTransmission();
	if (dataSize == Wire.requestFrom(address, dataSize))
	{
		return Wire.read();
	}
	return 0;
}

// Write a sequence of bytes starting at the given address
void I2CBase::writeRegisterMulti(const byte address, const byte regAddress, const byte* values, const uint32_t size)
{
	logDebug(address, false, regAddress, values, size);

	Wire.beginTransmission(address);
	Wire.write(regAddress);
	Wire.write(values, size);
	Wire.endTransmission();
}

// Read a number of bytes from the specified address, returns the number of bytes read.
uint32_t I2CBase::readRegisterMulti(const byte address, const byte regAddress, byte* values, const uint32_t size)
{
#ifdef _DEBUG
	logDebug(address, true, regAddress, values, size);
#endif

	Wire.beginTransmission(address);
	Wire.write(regAddress);
	Wire.endTransmission();
	const uint8_t bytesRead = Wire.requestFrom(address, size);
	if (bytesRead <= size)
	{
		for (uint8_t read = 0; read < bytesRead && Wire.available(); ++read)
		{
			values[read] = Wire.read();
		}
		logDebug(address, true, regAddress, values, bytesRead);
		return bytesRead;	// Return the number of bytes read
	}
	else
	{	// Too much data was read.
		return 0;
	}
}


// Write a single bit within a register
void I2CBase::writeRegisterBit(const byte address, const byte regAddress, const byte index, const bool value)
{
	if (index >= 0 && index < 8)
	{
		byte currentValue = readRegister(address, regAddress);
		if (value)
		{
			currentValue |= (1 << index);
		}
		else
		{
			currentValue = ~(1 << index);
		}
		writeRegister(address, regAddress, currentValue);
	}
}

// Read a single bit in a register.
bool I2CBase::readRegisterBit(const byte address, const byte regAddress, const byte index)
{
	if (index >= 0 && index < 8)
	{
		const byte currentValue = readRegister(address, regAddress);
		return (currentValue && (1 << index));
	}
	return false;
}

// Log the given data to the serial line in a standard format
void I2CBase::logDebug (const byte address, const String& message)
{
#ifdef _DEBUG		
			const String fullMessage  = String("I2CBase(")
								+ String(address, HEX)
								+ String(") : ") 
								+ message;
			Serial.println(fullMessage);
#endif
}

// Log the given data to the serial line in a standard format
void I2CBase::logDebug (const byte address, const bool bReading, const byte regAddress, const byte value, const uint32_t size)
{
#ifdef _DEBUG			
	String message  = String(bReading?"Reading":"Writing")
					+ String(" to register ")
					+ String(regAddress, HEX)
					+ String(" the value ")
					+ String(value, HEX);
	if (size > 1)
	{
		message += String(" to address ") + String((regAddress + size - 1), HEX);
	}
	logDebug(address, message);
#endif
}

///
void I2CBase::logDebug (const byte address, const bool bReading, const byte regAddress, const byte* values, const uint32_t size)
{
#ifdef _DEBUG
	String message = String(bReading ? "Reading" : "Writing")
		+ String(" to register ")
		+ String(regAddress, HEX);
	if (size > 1)
	{
		message += String(size + " values.");
		byte const* pCurrent = values;
		for (size_t item = 0; item < size; ++item, ++pCurrent)
		{
			message += String(*pCurrent, HEX) + String(", ");
		}
	}
	else
	{
		message += String(" the value ") + String(values[0], HEX);
	}
	logDebug(address, message);
#endif
}