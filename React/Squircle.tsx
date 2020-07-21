import * as React from "react";

interface SquircleProps {
  size: number;
  fill?: string;
}

export const Squircle: React.FC<SquircleProps> = ({ size, fill }) => {
  return (
    <svg
      viewBox={`0 0 ${size} ${size}`}
      xmlns="http://www.w3.org/2000/svg"
      width={size}
      height={size}
      className="squircle"
    >
      <path
        d={`
    M 0, ${size / 2}
    C 0, ${size * 0.125} ${size * 0.125}, 0 ${size / 2}, 0
    S ${size}, ${size * 0.125} ${size}, ${size / 2}
        ${size * 0.875}, ${size} ${size / 2}, ${size}
        0, ${size * 0.875} 0, ${size / 2}
`}
        fill={fill ?? "#000"}
      ></path>
    </svg>
  );
};
