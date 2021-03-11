import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from "@angular/common/http";
import { Observable } from "rxjs";


export class JwtInterceptor implements HttpInterceptor {
  constructor() { }
  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    let token = localStorage.getItem('jwt');
    req = req.clone({
      setHeaders: {
        Autorization: `Bearer ${token}`
      }
    });

    return next.handle(req);
  }
}
