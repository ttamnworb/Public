// I2CBaseTest.cpp : Test that I2CBase is working correctly
//

#include <iostream>
#include "WProgram.h"
#include "Wire.h"
#include "MemoryBlock.h"
#include "I2CBase.h"
#include "CDS1307.h"

// Setup
static CSerial Serial = CSerial();
static CWire Wire = CWire();

static MemoryBlock SimDS1307(0, 7, 0);

int main()
{
    Wire.addDevice(CDS1307::DefaultAddress, SimDS1307);

    CDS1307 ds1307;
    std::cout << ds1307.getTimeSeconds() << "\n";
    ds1307.setTimeSeconds(42);
    std::cout << ds1307.getTimeSeconds() << "\n";
}

