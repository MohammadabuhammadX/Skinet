export interface Pagination<T> {
    pageIndex: number;
    pageSize: number;
    count: number;
    data: T;
}

// export interface Daum {
//   id: number
//   name: string
//   description: string
//   price: number
//   pictureUrl: string
//   productType: string
//   productBrand: string
// }
