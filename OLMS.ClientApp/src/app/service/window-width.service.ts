import { Observable } from 'rxjs/Rx';
import { Injectable } from '@angular/core';

@Injectable()
export class WindowWidthService {

  private minWidthBreakpoint: number;

  public onResize(minWidthBreakpoint: number, scrollBar?: boolean): Observable<boolean | {}> {
    this.minWidthBreakpoint = minWidthBreakpoint;

    return Observable.fromEvent(window, 'resize')
      .map(() => this.assertSize(scrollBar))
      .startWith(this.assertSize(scrollBar))
      .distinctUntilChanged();
  }

  private assertSize(scrollBar?: boolean): boolean {
    const area = scrollBar ? window.innerWidth : document.documentElement.clientWidth;

    return this.minWidthBreakpoint <= area;
  }

}
