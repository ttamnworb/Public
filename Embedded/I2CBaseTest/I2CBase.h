// I2CBase
// Base class supporting multiple I2C devices.
// Matt 01/09/2016

#ifndef _M_I2CBASE_H_
#define _M_I2CBASE_H_

#if defined(ARDUINO)  
#include "arduino.h"
#else
#include "WProgram.h"
#endif

class I2CBase
{
public:
	// Class constructor
	// param address the address of the remote device that communication will be too.
	I2CBase(const byte address = 0);

	// Initialise the library
	// param address the address of the remote device that communication will be too.
	// Will override the address supplied to the constructor.
	// Used as an alternative to the constructor if the address is not know when the object is created.
	void begin(const byte address = 0);

	// Each register has 6 functions
	//    void setXXXX (const byte value)
	//    byte getXXXX ()
	//	  void setMultiXXXX(const byte* values, const uint32_t size)
    //    uint32_t getMultiXXXX (const byte* values, const uint32_t size)
	//    void setBitXXXX (const byte index, const byte value)
	//    bool getBitXXXX (const byte index)
#define REGISTERACCESS(fnname,reg) \
  void set##fnname (const byte value = 0x0){writeRegister (m_ModuleAddress, reg, value);} \
  byte get##fnname (void) {return readRegister(m_ModuleAddress, reg);} \
  void setMulti##fnname (const byte* values, const uint32_t size){writeRegisterMulti (m_ModuleAddress, reg, values, size);} \
  uint32_t getMulti##fnname (byte* values, const uint32_t size){return readRegisterMulti(m_ModuleAddress, reg, values, size);} \
  void setBit##fnname (const byte bitIndex, const bool value = false){writeRegisterBit (m_ModuleAddress, reg, bitIndex, value);} \
  bool getBit##fnname (const byte bitIndex){return readRegisterBit (m_ModuleAddress, reg, bitIndex);}

#define REGISTERREADONLY(fnname,reg) \
  byte get##fnname (void) {return readRegister(m_ModuleAddress, reg);} \
  uint32_t getMulti##fnname (byte* values, const uint32_t size){return readRegisterMulti(m_ModuleAddress, reg, values, size);} \
  bool getBit##fnname (const byte bitIndex){return readRegisterBit (m_ModuleAddress, reg, bitIndex);}

protected:
	// Write a single byte to the bus.
	// param address the address of the remote device that communication will be too.
	// param value 		
	static void writeByte(const byte address, const byte value);

	// Write a single byte to the specified register address
	static void writeRegister(const byte address, const byte regAddress, const byte value);
	// Read a single byte from the specified address.
	static byte readRegister(const byte address, const byte regAddress);

	// Write a sequence of bytes starting at the given address
	static void writeRegisterMulti(const byte address, const byte regAddress, const byte* values, const uint32_t size);
	// Read a number of bytes from the specified address, returns the number of bytes read.
	static uint32_t readRegisterMulti(const byte address, const byte regAddress, byte* values, const uint32_t size);

	// Set a single bit at an address, by reading and writing the value.
	static void writeRegisterBit(const byte address, const byte regAddress, const byte index, const bool value);
	// Read a single bit from the address.
	static bool readRegisterBit(const byte address, const byte regAddress, const byte index);

	// Get the modules address
	byte	getModuleAddress(void) const { return m_ModuleAddress; }
private:
	// Log the given data to the serial line in a standard format
	// param address : The destination module's address.
	// param message : The message to log.
	static void logDebug (const byte address, const String& message);
	// Log the given data to the serial line in a standard format
	// param address  : The destination module's address.
	// param bReading : The caller is reading from the register.
	// param regAddress : The address of the register being read from or written to.
	// param value : The raw value of the register
	// param size  : The number of bytes
	static void logDebug (const byte address, const bool bReading, const byte regAddress, const byte value, const uint32_t size = 1);
	// Log the given data to the serial line in a standard format
	// param address  : The destination module's address.
	// param bReading : The caller is reading from the register.
	// param regAddress : The address of the register beinge read from or written to.
	// param values : The array of values being written or read.
	// param size : The number of items in the array of values.
	static void logDebug (const byte address, const bool bReading, const byte regAddress, const byte* values, const uint32_t size);

protected:
	byte	m_ModuleAddress;
};


#endif
