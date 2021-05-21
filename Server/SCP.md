# Copy between remote and local machine

If you are on the computer from which you want to send file to a remote computer:

scp /file/to/send username@remote:/where/to/put
Here the remote can be a FQDN or an IP address.

On the other hand if you are on the computer wanting to receive file from a remote computer:

scp username@remote:/file/to/send /where/to/put
scp can also send files between two remote hosts:

scp username@remote_1:/file/to/send username@remote_2:/where/to/put
So the basic syntax is:

scp username@source:/location/to/file username@destination:/where/to/put

Copy recursively
scp -r

To specify custom port
scp -P 123
