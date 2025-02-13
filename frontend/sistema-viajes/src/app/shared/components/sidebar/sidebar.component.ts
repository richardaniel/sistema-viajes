import { Component, HostListener } from '@angular/core';
import { RouterLink, RouterLinkActive } from '@angular/router';


@Component({
  selector: 'app-sidebar',
  standalone:true,
  imports:[RouterLink],
  templateUrl: './sidebar.component.html',
  styleUrl: './sidebar.component.css'
})
export class SidebarComponent {
  showReportsMenu:boolean=false;

  toggleShowReportMenu():void{
    this.showReportsMenu=!this.showReportsMenu;
  }

  @HostListener ('document:mouseover',['$event'])
  closeReportMenu(event:MouseEvent):void{
    const reportEle = document.getElementById('reports')
    if(reportEle && !reportEle.contains(event.target as Node)){
      this.showReportsMenu=false
    }else{
      this.showReportsMenu=true;
    }
  }
}
