#include "Callback.h"

void _CallPlugin (int x, void* methodHandle, CallbackCaller caller){
    (caller)(x * 2, methodHandle);
}