// X and Y should be relative to a centerpoint
export const angleByCoordinates = (x:number, y:number) => Math.atan2(y,x) * 180/Math.PI;
