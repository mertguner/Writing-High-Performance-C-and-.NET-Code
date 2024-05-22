// dllmain.cpp : Defines the entry point for the DLL application.
#include "pch.h"
#include <vector>

BOOL APIENTRY DllMain( HMODULE hModule,
                       DWORD  ul_reason_for_call,
                       LPVOID lpReserved
                     )
{
    switch (ul_reason_for_call)
    {
    case DLL_PROCESS_ATTACH:
    case DLL_THREAD_ATTACH:
    case DLL_THREAD_DETACH:
    case DLL_PROCESS_DETACH:
        break;
    }
    return TRUE;
}

std::vector<int> sieveOfEratosthenesFalse(int n) {
    std::vector<bool> isPrime(n + 1, true);
    isPrime[0] = isPrime[1] = false;

    for (int p = 2; p * p <= n; ++p) {
        if (isPrime[p]) {
            for (int i = p * p; i <= n; i += p) {
                isPrime[i] = false;
            }
        }
    }
    std::vector<int> primes;
    for (int i = 2; i <= n; ++i) {
        if (isPrime[i]) {
            primes.push_back(i);
        }
    }

    return primes;
}

std::vector<int> sieveOfEratosthenes(int n) {
    std::vector<uint8_t> isPrime(n + 1, 1);
    isPrime[0] = isPrime[1] = 0;

    for (int p = 2; p * p <= n; ++p) {
        if (isPrime[p]) {
            for (int i = p * p; i <= n; i += p) {
                isPrime[i] = 0;
            }
        }
    }

    std::vector<int> primes;

    for (int i = 2; i <= n; ++i) {
        if (isPrime[i]) {
            primes.push_back(i);
        }
    }

    return primes;
}


extern "C" __declspec(dllexport) int sieveOfEratosthenesTest(int refCode)
{
    return sieveOfEratosthenes(refCode).size();
}

extern "C" __declspec(dllexport) int sieveOfEratosthenesFalseTest(int refCode)
{
    return sieveOfEratosthenesFalse(refCode).size();
}