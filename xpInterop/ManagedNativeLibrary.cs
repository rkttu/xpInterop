using System;
using System.Reflection;
using System.Runtime.InteropServices;

namespace xpInterop
{
    public class ManagedNativeLibrary : IManagedNativeLibrary
    {
        private bool _disposed;
        private readonly IntPtr _libHandle;

        public ManagedNativeLibrary(string libraryPath)
        {
            _libHandle = NativeLibrary.Load(libraryPath);
        }

        public ManagedNativeLibrary(string libraryPath, Assembly assembly, DllImportSearchPath? searchPath)
        {
            _libHandle = NativeLibrary.Load(libraryPath, assembly, searchPath);
        }

        public virtual IntPtr GetExport(string exportedName)
        {
            ThrowIfDisposed();
            return NativeLibrary.GetExport(_libHandle, exportedName);
        }

        public virtual T GetFunction<T>(string exportedName)
            where T : Delegate
        {
            ThrowIfDisposed();
            var address = GetExport(exportedName);
            return Marshal.GetDelegateForFunctionPointer<T>(address);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                _disposed = true;
                NativeLibrary.Free(_libHandle);
            }
        }

        ~ManagedNativeLibrary()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void ThrowIfDisposed()
        {
            if (_disposed)
                ThrowObjectDisposedException();
        }

        private void ThrowObjectDisposedException()
            => throw new ObjectDisposedException(GetType().Name, "Native library already dispoed.");
    }
}
