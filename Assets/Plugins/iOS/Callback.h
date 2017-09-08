extern "C" {
    typedef void (*CallbackCaller)(int x, void* methodHandle);
    void _CallPlugin (int x, void* methodHandle, CallbackCaller caller);
}