console = {
    log: SHIM.ConsoleLog
};

NOOP = function () {};

// make Packages undefined to force r.js to skip over env = rhino
(function (undefined) { Packages = undefined; } ());

// node module object
module = {
    exports: {}
};

// Fake node process object
process = {
    argv: Array.prototype.concat(['RN'], ['r.js'], SHIM.Args()),
    stdout: {fd:''},
    exit: NOOP
};

console.log('proc args ' + process.argv);

console.log('proc args' + process.argv.length);

// fake node require
require = function (name) {

    if (name === 'fs') {

        return {
            existsSync: SHIM.FsExists,
            readFileSync: SHIM.FsReadFileSync,
            realpathSync: SHIM.PathResolve,
            writeSync: NOOP,
            fsyncSync: NOOP
        }
    };

    if (name === 'vm') {
        return {
            runInThisContext: SHIM.VmRunInThisContext
        }
    };

    if (name === 'path') {
        return {
            resolve: SHIM.PathResolve
        }
    };

};

require.main = module;