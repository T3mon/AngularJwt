"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.JwtInterceptor = void 0;
var JwtInterceptor = /** @class */ (function () {
    function JwtInterceptor() {
    }
    JwtInterceptor.prototype.intercept = function (req, next) {
        var token = localStorage.getItem('jwt');
        req = req.clone({
            setHeaders: {
                Autorization: "Bearer " + token
            }
        });
        return next.handle(req);
    };
    return JwtInterceptor;
}());
exports.JwtInterceptor = JwtInterceptor;
//# sourceMappingURL=jwt-interceptor.js.map