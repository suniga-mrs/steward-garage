import type { Component } from 'vue';
import type { RouteComponent, RouteRecordRedirectOption } from 'vue-router';

export type Lazy<T> = () => Promise<T>;

declare interface IBaseNavigationItem {
  name: string;
  route: string;
  title: string;
  placement?: string[];
  children?: IBaseNavigationItem[];
}

export declare interface INavigationItemChildView extends IBaseNavigationItem {
  view: RouteComponent;
  children?: INavigationItemChildView[];
  layout?: Component;
  redirect?: never;
}

declare interface INavigationItemView extends IBaseNavigationItem {
  layout: Component;
  view: RouteComponent;
  redirect?: RouteRecordRedirectOption | undefined;
  children?: INavigationItemChildView[];
}

declare interface INavigationItemRedirect extends IBaseNavigationItem {
  layout: Component;
  redirect: RouteRecordRedirectOption;
  view?: Component | undefined;
  children?: INavigationItemChildView[];
}

export type TNavigationItem = INavigationItemView | INavigationItemChildView;

export interface INavigationItem {
  name: string;
  route: string;
  title: string;
  layout?: Component;
  view?: RouteComponent;
  children?: Array<INavigationItem>;
}
